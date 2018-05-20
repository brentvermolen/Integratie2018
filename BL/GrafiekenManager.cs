using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
   public class GrafiekenManager
   {
      private readonly GrafiekRepository repo;
      private readonly BerichtManager berichtMng = new BerichtManager();

      public GrafiekenManager()
      {
         repo = new GrafiekRepository();
      }

      public IEnumerable<Grafiek> GetGrafieken()
      {
         List<Grafiek> gs = repo.ReadGrafieken().ToList();
         for(int i = 0; i < gs.Count; i++)
         {
            gs[i] = CreateGrafiek(gs[i]);
         }
         return gs;
      }

      public Grafiek NewGrafiek()
      {
         return repo.CreateGrafiek();
      }

      public Persoon GetPersoon(int persoon)
      {
         return repo.ReadPersoon(persoon);
      }

      public void AddGrafiek(Grafiek grafiek)
      {
         repo.SaveGrafiek(grafiek);
      }

      public void RemoveGrafiek(int ID)
      {
         repo.DeleteGrafiek(ID);
      }

      public static double ConvertToUnixTimestamp(DateTime date)
      {
         DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
         TimeSpan diff = date.ToUniversalTime() - origin;
         return Math.Floor(diff.TotalSeconds);
      }

      public Grafiek CreateGrafiek(Grafiek grafiek)
      {
         switch (grafiek.Chart.Type)
         {
            case "normal":
               grafiek.Series = new List<Serie>();
               grafiek.yAs = new As() { IsUsed = true, Titel = grafiek.TitelYAs };

               foreach (Persoon persoon in grafiek.Personen)
               {
                  AantalBerichtenPerWeekModel model2 = GetAantalBerichtenPerWeekModel(grafiek.AantalSeries, persoon.ID);
                  DateTime start = new DateTime(model2.StartJaar, model2.StartMaand, model2.StartDag);
                  start = start.AddHours(2);
                  grafiek.PointStart = ConvertToUnixTimestamp(start);
                  Serie serie = new Serie();
                  serie.Naam = persoon.Naam;

                  foreach (int d in model2.Data)
                  {
                     Data dat = new Data(d);
                     serie.Data.Add(dat);
                  }

                  grafiek.Series.Add(serie);
               }
               grafiek.PlotOptions.PointStart = grafiek.PointStart.ToString() + "000";
               return grafiek;
            case "column":
               grafiek.xAs = new As() { IsUsed = true, Categorieen = grafiek.Categorieen };
               grafiek.yAs = new As() { IsUsed = true, Titel = grafiek.TitelYAs };
               grafiek.Series = new List<Serie>();

               foreach (Persoon persoon in grafiek.Personen)
               {
                  int id = persoon.ID;
                  int aantal = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == id) != null).ToList().Count;
                  Serie serie = new Serie();
                  serie.Naam = berichtMng.GetPersoon(id).Naam;

                  serie.Data.Add(new Data(aantal) { Naam = grafiek.TitelXAs });
                  grafiek.Series.Add(serie);
               }

               return grafiek;
            case "pie":
               int intTeller;
               PieDataPersoonModel model = new PieDataPersoonModel()
               {
                  Persoon = grafiek.Personen[0],
                  Series = new List<string>(),
                  Waarden = new List<double>()
               };
               
               int intID = model.Persoon.ID;

               switch (grafiek.ContentType)
               {
                  case "Verhalen":
                     List<Url> urls = berichtMng.GetUrls().Where(w => w.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null) != null).ToList();
                     urls.Sort((w1, w2) => w2.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count.CompareTo(w1.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count));

                     intTeller = 0;
                     while (model.Series.Count < grafiek.AantalSeries)
                     {
                        Url url = urls[intTeller];

                        model.Series.Add(url.Tekst);
                        model.Waarden.Add(url.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count);

                        intTeller++;
                     }

                     break;
                  case "Woorden":
                     List<Woord> woorden = berichtMng.GetWoorden().Where(w => w.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null) != null).ToList();
                     woorden.Sort((w1, w2) => w2.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count.CompareTo(w1.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count));

                     intTeller = 0;
                     while (model.Series.Count < grafiek.AantalSeries)
                     {
                        Woord woord = woorden[intTeller];
                        if (!model.Persoon.Naam.ToLower().Contains(woord.Tekst.ToLower()))
                        {
                           model.Series.Add(woord.Tekst);
                           model.Waarden.Add(woord.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count);
                        }
                        intTeller++;
                     }

                     break;
                  case "Themas":
                     return null;
                  case "Gemeente":
                     //var berichten = berichtMng.GetBerichten().GroupBy(b => b.Geo);
                     break;
                  case "Geslacht":
                     var geslacht = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Geslacht);

                     geslacht = geslacht.OrderByDescending(p => p.Count());

                     foreach (var group in geslacht)
                     {
                        if (group.Key.Equals("f"))
                        {
                           model.Series.Add("Vrouw");
                        }
                        else
                        {
                           model.Series.Add("Man");
                        }
                        model.Waarden.Add(group.Count());
                     }

                     break;
                  case "Leeftijd":
                     var leeftijd = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Leeftijd);

                     leeftijd = leeftijd.OrderByDescending(p => p.Count());

                     foreach (var group in leeftijd)
                     {
                        if (group.Key.Equals(""))
                        {
                           model.Series.Add("Andere");
                        }
                        else
                        {
                           model.Series.Add(group.Key);
                        }
                        model.Waarden.Add(group.Count());
                     }

                     break;
                  case "Opleiding":
                     var opleiding = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Scholing);

                     opleiding = opleiding.OrderByDescending(p => p.Count());

                     foreach (var group in opleiding)
                     {
                        if (group.Key.Equals(""))
                        {
                           model.Series.Add("Andere");
                        }
                        else
                        {
                           model.Series.Add(group.Key);
                        }
                        model.Waarden.Add(group.Count());
                     }

                     break;
                  case "Taal":
                     var taal = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Taal);

                     taal = taal.OrderByDescending(p => p.Count());

                     foreach (var group in taal)
                     {
                        if (group.Key.Equals(""))
                        {
                           model.Series.Add("Andere");
                        }
                        else
                        {
                           model.Series.Add(group.Key);
                        }
                        model.Waarden.Add(group.Count());
                     }

                     break;
                  case "Persoonlijkheid":
                     var persoonlijkheid = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Persoonlijkheid);

                     persoonlijkheid = persoonlijkheid.OrderByDescending(p => p.Count());

                     foreach (var group in persoonlijkheid)
                     {
                        if (group.Key.Equals(""))
                        {
                           model.Series.Add("Andere");
                        }
                        else
                        {
                           model.Series.Add(group.Key);
                        }
                        model.Waarden.Add(group.Count());
                     }
                     break;
                  case "Trend":
                     return null;
               }

               Serie serie2 = new Serie()
               {
                  Naam = grafiek.TitelXAs,
                  ColorByPoint = true
               };

               for (int i = 0; i < model.Series.Count; i++)
               {
                  Data data = new Data(model.Waarden[i]) { Naam = model.Series[i] };
                  if (i == 0)
                  {
                     data.Selected = true;
                     data.Sliced = true;
                  }
                  serie2.Data.Add(data);
               }
               grafiek.Series.Add(serie2);

               return grafiek;
         }

         return grafiek;
      }

      public class PieDataPersoonModel
      {
         public Persoon Persoon { get; set; }
         public List<string> Series { get; set; }
         public List<double> Waarden { get; set; }
      }

      public AantalBerichtenPerWeekModel GetAantalBerichtenPerWeekModel(int intAantalWeken, int intID)
      {
         //Vanaf Maandag van deze week (Dus als vandaag = woensdag, vanaf afgelopen maandag tot nu woensdag) (Enkel tweets van 3dagen)
         /*int dezeWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

         int eersteWeek = dezeWeek - intAantalWeken;
         DateTime datumVandaag = new DateTime(DateTime.Today.Year, 1, 1).AddDays(dezeWeek * 7 - 7);
         datumVandaag = datumVandaag.AddDays(0 - (intAantalWeken * 7 - 7));

         List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null && b.Datum >= datumVandaag).ToList();

         var test = berichts.GroupBy(t => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(t.Datum, CalendarWeekRule.FirstDay, DayOfWeek.Monday));
         List<AantalBerichtenPerWeek> lijst = new List<AantalBerichtenPerWeek>();

         while (eersteWeek++ < dezeWeek)
         {
            lijst.Add(new AantalBerichtenPerWeek() { Week = datumVandaag, Count = 0 });
            datumVandaag = datumVandaag.AddDays(7);
         }

         int i = 0;

         DateTime date = new DateTime(DateTime.Today.Year, 1, 1);
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

         return model;*/

         //Vanaf maandag van vorige week (Dus als vandaag = Woensdag, vanaf vorige week maandag tot vorige zondag) (Tweets van deze week niet)
         /*int dezeWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
         dezeWeek--;

         int eersteWeek = dezeWeek - intAantalWeken;
         DateTime datumVandaag = new DateTime(DateTime.Today.Year, 1, 1).AddDays(dezeWeek * 7 - 7);
         datumVandaag = datumVandaag.AddDays(0 - (intAantalWeken * 7 - 7));

         List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null && b.Datum >= datumVandaag).ToList();

         List<AantalBerichtenPerWeek> lijst = new List<AantalBerichtenPerWeek>();

         while (eersteWeek++ < dezeWeek)
         {
            int week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datumVandaag, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            lijst.Add(new AantalBerichtenPerWeek() { Week = datumVandaag, Count = berichts.Where(b => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(b.Datum, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == week).Count() });
            datumVandaag = datumVandaag.AddDays(7);
         }

         lijst.Sort((m1, m2) => m1.Week.CompareTo(m2.Week));

         DateTime vroegste = lijst.Min(l => l.Week);

         AantalBerichtenPerWeekModel model = new AantalBerichtenPerWeekModel()
         {
            ID = intID,
            Naam = berichtMng.GetPersoon(intID).Naam,
            StartJaar = vroegste.Year,
            StartMaand = vroegste.Month,
            StartDag = vroegste.Day,
            Data = new List<int>()
         };


         for (int i = 0; i < lijst.Count; i++)
         {
            model.Data.Add(lijst[i].Count);
         }

         return model;*/

         //Vanaf vandaag een week geleden (Als vandaag = Donderdag, laatste serie = vorige donerdag tot nu) (Alle tweets)
         List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList();

         List<AantalBerichtenPerWeek> lijst = new List<AantalBerichtenPerWeek>();
         DateTime datumVandaag = DateTime.Today.AddDays(-7);
         int week = 0;
         while (week++ < intAantalWeken)
         {
            lijst.Add(new AantalBerichtenPerWeek() { Week = datumVandaag, Count = berichts.Where(b => b.Datum >= datumVandaag).Count() });
            berichts.RemoveAll(b => b.Datum >= datumVandaag);
            datumVandaag = datumVandaag.AddDays(-7);
         }

         lijst.Sort((m1, m2) => m1.Week.CompareTo(m2.Week));

         DateTime vroegste = lijst.Min(l => l.Week);

         AantalBerichtenPerWeekModel model = new AantalBerichtenPerWeekModel()
         {
            ID = intID,
            Naam = berichtMng.GetPersoon(intID).Naam,
            StartJaar = vroegste.Year,
            StartMaand = vroegste.Month,
            StartDag = vroegste.Day,
            Data = new List<int>()
         };


         for (int i = 0; i < lijst.Count; i++)
         {
            model.Data.Add(lijst[i].Count);
         }

         return model;
      }

      public class AantalBerichtenPerWeekModel
      {
         public int ID { get; set; }
         public string Naam { get; set; }
         public int StartJaar { get; set; }
         public int StartMaand { get; set; }
         public int StartDag { get; set; }
         public List<int> Data { get; set; }
      }

      private class AantalBerichtenPerWeek
      {
         public int Count { get; set; }
         public DateTime Week { get; set; }
      }

      public void ChangeGrafiek(Grafiek grafiek)
      {
         repo.UpdateGrafiek(grafiek);
      }
   }
}
