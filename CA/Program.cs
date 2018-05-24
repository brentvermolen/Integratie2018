using BL;
using BL.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CA
{
    class Program
    {
        private static Synchronize sync;
        private static BerichtManager berichtMng = new BerichtManager();
        private static SyncManager syncMng = new SyncManager();
        private static AlertManager alertMng = new AlertManager();

        static void Main(string[] args)
        {
            Console.WriteLine("Synchronisatie");
            Console.WriteLine("========================================");

            Console.WriteLine("Klaarmaken Voor Synchronisatie");
            sync = syncMng.GetSync();

            /*Console.WriteLine("Synchronisatie Starten");
            StartAsync().Wait();
            Console.ReadKey();
            Console.WriteLine();*/
            Console.WriteLine("Berichten Analyseren");
            AnalyseerBerichten();
            Console.WriteLine("Geanalyseerd");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Alerts");
            Console.WriteLine("========================================");
            Console.WriteLine("Alerts Worden Nagekeken");
            CheckAlerts();
            Console.ReadKey();
        }

        private static void AnalyseerBerichten()
        {
            List<Persoon> Personen = berichtMng.GetPersonen(true).ToList();
            DateTime dateVandaag = DateTime.Now.AddDays(-2);
            DateTime dateGisteren = DateTime.Now.AddDays(-4);

            List<Bericht> AlleBerichten = berichtMng.GetBerichten(b => b.Datum >= dateGisteren).ToList();

            foreach (Persoon persoon in Personen)
            {
                List<Bericht> berichtenGisteren = AlleBerichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == persoon.ID) != null && b.Datum >= dateGisteren).ToList();
                List<Bericht> berichtenVandaag = berichtenGisteren.Where(b => b.Datum >= dateVandaag).ToList();

                int nieuw = berichtenVandaag.Count;
                int oud = berichtenGisteren.Count - nieuw;
                if (oud == 0)
                {
                    oud = 1;
                }

                double percentage = ((double)(nieuw - oud) / oud) * 100;

                if (persoon.Trending != percentage)
                {
                    persoon.Trending = percentage;

                    berichtMng.ChangePersoon(persoon);
                }
            }
        }

        private class AlertResultaat
        {
            public Alert Alert { get; set; }
            public Gebruiker Gebruiker { get; set; }
            public string Info { get; set; }
            public string Resultaat { get; set; }
        }

        private static void CheckAlerts()
        {
            try
            {
                List<AlertResultaat> alertResultaats = new List<AlertResultaat>();

                List<Alert> alerts = alertMng.GetAlerts().Where(a => a.Ingeschakeld == true).ToList();
                foreach (Alert alert in alerts)
                {
                    Persoon persoon = alert.Persoon;


                    switch (alert.Type)
                    {
                        case Alert.AlertType.BEIDE:
                        case Alert.AlertType.DALING:
                        case Alert.AlertType.STIJGING:

                            DateTime date = DateTime.Now;
                            date = date.AddDays(-2);
                            List<Bericht> berichtenPersoon = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == persoon.ID) != null && b.Datum >= date).ToList();
                            List<int> berichtenPerDag = new List<int>();

                            for (int i = 0; i < 7; i++)
                            {
                                berichtenPerDag.Add(berichtenPersoon.Where(b => b.Datum.DayOfWeek == ((DayOfWeek)i)).Count());
                            }

                            double afwijking = BerekenAfwijking(berichtenPerDag);
                            int aantalVandaag = berichtenPersoon.Where(b => b.Datum.Date == DateTime.Today.Date).Count();

                            double Zscore = (aantalVandaag - berichtenPerDag.Average()) / afwijking;

                            if (Zscore < -1)
                            {
                                alertResultaats.Add(new AlertResultaat()
                                {
                                    Alert = alert,
                                    Gebruiker = alert.Gebruiker,
                                    Info = "Daling",
                                    Resultaat = Zscore.ToString()
                                });
                            }
                            else if (Zscore > 1)
                            {
                                alertResultaats.Add(new AlertResultaat()
                                {
                                    Alert = alert,
                                    Gebruiker = alert.Gebruiker,
                                    Info = "Trending",
                                    Resultaat = Zscore.ToString()
                                });
                            }
                            break;
                    }
                }

                Console.WriteLine("Alerts Zijn Nagekeken");

                foreach (AlertResultaat res in alertResultaats)
                {
                    Console.WriteLine("\t" + res.Alert.ID + " van " + res.Gebruiker.Email + ": " + res.Alert.Persoon.Naam + " " + res.Info);
                }
            }
            catch (Exception e)
            {
                e.ToString();
                Console.WriteLine("Iets mislukt bij nakijken van alerts");
            }
        }

        public static double BerekenAfwijking(List<int> totalen)
        {
            //Compute the Average      
            double avg = totalen.Average();
            //Perform the Sum of (value-avg)_2_2      
            double sum = totalen.Sum(d => Math.Pow(d - avg, 2));
            //Put it all together      
            return Math.Sqrt((sum) / (totalen.Count() - 1));
        }

        private AantalBerichtenPerWeekModel GetAantalBerichtenPerWeekModel(int intAantalWeken, int intID)
        {
            int dezeWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            int eersteWeek = dezeWeek - intAantalWeken;
            DateTime datumVandaag = new DateTime(2018, 1, 1).AddDays(dezeWeek * 7 - 7);
            datumVandaag = datumVandaag.AddDays(0 - (intAantalWeken * 7 - 7));

            List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null && b.Datum >= datumVandaag).ToList();

            var test = berichts.GroupBy(t => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(t.Datum, CalendarWeekRule.FirstDay, DateTime.Today.DayOfWeek));
            List<AantalBerichtenPerWeek> lijst = new List<AantalBerichtenPerWeek>();

            while (eersteWeek++ < dezeWeek)
            {
                lijst.Add(new AantalBerichtenPerWeek() { Week = datumVandaag, Count = 0 });
                datumVandaag = datumVandaag.AddDays(7);
            }

            int i = 0;

            DateTime date = new DateTime(2018, 1, 1);
            int minsteWeek = test.Min(w => w.Key);
            date = date.AddDays(minsteWeek * 7 - 7);

            test = test.OrderBy(t => t.Key);

            foreach (var key in test)
            {
                int aantal = key.Count();

                AantalBerichtenPerWeek item = lijst[i++];

                while (item.Week != date)
                {
                    item = lijst[i++];
                }

                if (item.Week == date)
                {
                    item.Count = aantal;
                    date = date.AddDays(7);
                }
            }
            lijst.Sort((m1, m2) => m1.Week.CompareTo(m2.Week));

            DateTime vroegste = lijst.Min(l => l.Week);

            AantalBerichtenPerWeekModel model = new AantalBerichtenPerWeekModel()
            {
                ID = intID,
                Naam = berichtMng.GetPersoon(intID).Naam,
                StartJaart = vroegste.Year,
                StartMaand = vroegste.Month,
                StartDag = vroegste.Day,
                Data = new List<int>()
            };

            for (i = 0; i < lijst.Count; i++)
            {
                model.Data.Add(lijst[i].Count);
            }

            return model;
        }

        private class AantalBerichtenPerWeekModel
        {
            public int ID { get; set; }
            public string Naam { get; set; }
            public int StartJaart { get; set; }
            public int StartMaand { get; set; }
            public int StartDag { get; set; }
            public List<int> Data { get; set; }
        }

        private class AantalBerichtenPerWeek
        {
            public int Count { get; set; }
            public DateTime Week { get; set; }
        }

        public static async Task StartAsync()
        {
            await ApiCallAsync();
        }

        public static string GetSince()
        {
            return string.Format("{0:d MMM yyyy HH:mm:ss}", sync.LaatsteSync);
        }
        //TODO: Timer zetten, elk uur inladen

        private static readonly HttpClient client = new HttpClient();

        public static async Task ApiCallAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                {
                    CharSet = "utf-8"
                });
                DateTime date = sync.LaatsteSync;
                string body = "{ \"since\":\"" + GetSince() + "\" }";
                sync.LaatsteSync = DateTime.Now;

                StringContent content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
                Console.WriteLine(body);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                {
                    CharSet = "utf-8"
                };
                content.Headers.Add("X-API-Key", "aEN3K6VJPEoh3sMp9ZVA73kkr");

                /*HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://kdg.textgain.com/query");
                requestMessage.Content = content*/
                HttpResponseMessage response = await client.PostAsync("https://kdg.textgain.com/query", content);
                //HttpResponseMessage response = await client.SendAsync(requestMessage);

                string responseString = await response.Content.ReadAsStringAsync();

                /*using (StreamReader sr = new StreamReader("C:\\Users\\Daan\\Desktop\\Integratie\\IntegratieMaster\\MVCIntegratie\\Content\\alljson.txt"))
                {
                   responseString = sr.ReadToEnd();
                }

                responseString.ToString();*/

                AddBerichten(responseString, date);

                Console.WriteLine("Synchronisatie Geslaagd");
                syncMng.ChangeSync(sync);
            }
            catch (Exception e)
            {
                e.ToString();
                Console.WriteLine("Synchronisatie Mislukt");
            }
        }

        private class BerichtenClass
        {
            [JsonProperty("berichten")]
            public List<Bericht> Berichten { get; set; }
        }

        public static IEnumerable<Bericht> AddBerichten(string json, DateTime date)
        {
            json = "{ \"berichten\": " + json + " }";
            json = json.Replace("\"geo\": false", "\"geo\": [0, 0]");
            json = json.Replace("\"geo\": [null, null]", "\"geo\": [0, 0]");

            BerichtenClass BerichtenJson;
            try
            {
                BerichtenJson = JsonConvert.DeserializeObject<BerichtenClass>(json);
            }
            catch (Exception e)
            {
                e.ToString();
                BerichtenJson = null;
            }

            BerichtenJson.ToString();

            int count = 0;
            List<Bericht> toeTeVoegen = BerichtenJson.Berichten.Where((b) => b.Datum >= date).ToList();
            berichtMng.AddBerichten(toeTeVoegen);

            Console.WriteLine(toeTeVoegen.Count.ToString() + " Toegevoegd");
            return BerichtenJson.Berichten;
        }
    }
}
