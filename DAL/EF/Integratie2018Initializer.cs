using BL.Domain;

using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
  public class Integratie2018Initializer : DropCreateDatabaseIfModelChanges<Integratie2018Context>
  {
    private static Synchronize sync;

    protected override void Seed(Integratie2018Context context)
    {

      AddDeelplatform(context);

      //AddGrafieken(context);

      AddFaq(context);

      AddPersonen(context);

      Synchronize sync = new Synchronize()
      {
        LaatsteSync = new DateTime(2018, 3, 1)
      };
      context.Synchronizes.Add(sync);

      context.SaveChanges();

      Console.WriteLine("Klaarmaken Voor Synchronisatie");

      Console.WriteLine("Synchronisatie Starten");
      StartAsync(context).Wait();


    }
    public static async Task StartAsync(Integratie2018Context context)
    {
      await ApiCallAsync(context);
    }

    public static string GetSince()
    {
      return string.Format("{0:d MMM yyyy HH:mm:ss}", sync.LaatsteSync);
    }
    //TODO: Timer zetten, elk uur inladen

    private static readonly HttpClient client = new HttpClient();

    public static async Task ApiCallAsync(Integratie2018Context context)
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



        responseString.ToString();

        AddBerichten(responseString, date, context);

        Console.WriteLine("Synchronisatie Geslaagd");
        
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

    public static IEnumerable<Bericht> AddBerichten(string json, DateTime date, Integratie2018Context context)
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
      List<Bericht> toeTeVoegen = BerichtenJson.Berichten.FindAll((b) => b.Datum >= date);
      context.Berichten.AddRange(toeTeVoegen);

      Console.WriteLine(toeTeVoegen.Count.ToString() + " Toegevoegd");
      return BerichtenJson.Berichten;
    }
    private void AddPersonen(Integratie2018Context context)
    {
      using (StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\politici.json")))
      {
        PersonenJson personen = JsonConvert.DeserializeObject<PersonenJson>("{ \"personen\": " + sr.ReadToEnd() + " }");

        int platformID = 1;
        foreach (Persoon p in personen.Personen)
        {
          p.DeelplatformID = platformID;
        }

        context.Personen.AddRange(personen.Personen);
        context.SaveChanges();
      }
    }

    public class PersonenJson
    {
      [JsonProperty("personen")]
      public List<Persoon> Personen { get; set; }
    }

    private void AddDeelplatform(Integratie2018Context context)
    {
      Deelplatform d1 = new Deelplatform()
      {
        Naam = "Politieker Barometer"
      };

      Deelplatform d2 = new Deelplatform()
      {
        Naam = "K3 Zoekt K3"
      };

      context.Deelplatformen.Add(d1);
      context.Deelplatformen.Add(d2);

      context.SaveChanges();
    }

    private void AddFaq(Integratie2018Context context)
    {
      FAQ faq1 = new FAQ()
      {
        Vraag = "Hoe gebruik ik de website?",
        Antwoord = "De website is zo ontworpen dat alles voor zich spreekt. Moest je een specifieke functie niet vinden kan je altijd de admin contacteren. ",
        Categorie = FAQCategorie.Website,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq2 = new FAQ()
      {
        Vraag = "Wat is het doel van deze website?",
        Antwoord = "Het doel van de website is om aan de hand van onze dashboards inzicht te geven voor burgers wat er op social media beweegt rond een bepaald maatschappelijk facet.",
        Categorie = FAQCategorie.Website,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq3 = new FAQ()
      {
        Vraag = "Hoe maak ik een nieuwe grafiek aan?",
        Antwoord = "Je kan een nieuwe grafiek aanmaken door op de knop 'Nieuwe Grafiek' te klikken",
        Categorie = FAQCategorie.Website,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq4 = new FAQ()
      {
        Vraag = "Hoe pas ik de instellingen van mijn account aan?",
        Antwoord = "Dit kan je doen door op de hoofdpagina op de naam van je account te klikken. Zorg eerst dat je bent ingelogd. ",
        Categorie = FAQCategorie.Account,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq5 = new FAQ()
      {
        Vraag = "Hoe log ik in met een multimedia account?",
        Antwoord = "Als je op de knop 'aanmelden' klikt kan je kiezen om in te loggen via Google, Facebook, Twitter en Microsoft.",
        Categorie = FAQCategorie.Account,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq6 = new FAQ()
      {
        Vraag = "Hoe verander ik mijn email adres?",
        Antwoord = "Zorg eerst dat je bent ingelogd. Daarna ga je naar accountinstellingen. Hoe je deze benadert vind je in 1 van de andere vragen.",
        Categorie = FAQCategorie.Account,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq7 = new FAQ()
      {
        Vraag = "Hoe verander ik mijn wachtwoord?",
        Antwoord = "Net zoals het wijzigen van andere instellingen vind je deze onder account instellingen.",
        Categorie = FAQCategorie.Account,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq8 = new FAQ()
      {
        Vraag = "Hoe pas ik de meldingen aan?",
        Antwoord = "De instellingen voor de meldingen vind je onder account instellingen. Hier kies je dan het platform waarvoor je de meldingen wilt wijzigen.",
        Categorie = FAQCategorie.Notificaties,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq9 = new FAQ()
      {
        Vraag = "Hoe kan ik kiezen wat ik via mail wil ontvangen?",
        Antwoord = "De instellingen voor het ontvangen van mail vind je onder meldingen",
        Categorie = FAQCategorie.Notificaties,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq10 = new FAQ()
      {
        Vraag = "Ik krijg geen meldingen, wat nu?",
        Antwoord = "Controleer of je meldingen aanstaan. Als dit het geval is kijk na of je email adres juist geschreven is. Voor web notificaties  " +
         "kijk na of deze aanstaan in je browser. Als je nog steeds geen meldingen krijgt contacteer dan de admin",
        Categorie = FAQCategorie.Notificaties,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq11 = new FAQ()
      {
        Vraag = "Ik wil een melding krijgen via sms?",
        Antwoord = "Helaas is dit type van melding nog niet geimplementeerd. Je kan momenteel via mail, de browser en de app meldingen ontvangen",
        Categorie = FAQCategorie.Notificaties,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };


      FAQ faq12 = new FAQ()
      {
        Vraag = "Kan ik ook via mijn gsm de website bereiken?",
        Antwoord = "Onze website is ook voorzien van een mobiele versie, moest dit niet duidelijk genoeg zijn kan je ook altijd onze app downloaden",
        Categorie = FAQCategorie.Overig,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq13 = new FAQ()
      {
        Vraag = "Waar kan ik de app downloaden?",
        Antwoord = "Op onze website vind je de download link voor onze app. Je kan ook via de playstore zoeken naar PolBarometer.",
        Categorie = FAQCategorie.Overig,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };

      FAQ faq14 = new FAQ()
      {
        Vraag = "Ik kan niet registreren?",
        Antwoord = "Zorg dat je gegevens correct zijn geschreven. Als je email adres niet klopt zal je geen account kunnen aanmaken.",
        Categorie = FAQCategorie.Overig,
        Beantwoord = true,
        BeantwoordOp = DateTime.Now,
        DeelplatformID = 1
      };



      context.FAQ.Add(faq1);
      context.FAQ.Add(faq2);
      context.FAQ.Add(faq3);
      context.FAQ.Add(faq4);
      context.FAQ.Add(faq5);
      context.FAQ.Add(faq6);
      context.FAQ.Add(faq7);
      context.FAQ.Add(faq8);
      context.FAQ.Add(faq9);
      context.FAQ.Add(faq10);
      context.FAQ.Add(faq11);
      context.FAQ.Add(faq12);
      context.FAQ.Add(faq13);
      context.FAQ.Add(faq14);

      context.SaveChanges();
    }

    private void AddGrafieken(Integratie2018Context context)
    {
      Serie serie1 = new Serie() { Naam = "Installation" };
      Data data1 = new Data() { Value = 43934 };
      Data data2 = new Data() { Value = 52503 };
      Data data3 = new Data() { Value = 57177 };
      Data data4 = new Data() { Value = 69658 };
      Data data5 = new Data() { Value = 97031 };
      Data data6 = new Data() { Value = 119931 };
      Data data7 = new Data() { Value = 137133 };
      Data data8 = new Data() { Value = 154175 };
      serie1.Data.Add(data1);
      serie1.Data.Add(data2);
      serie1.Data.Add(data3);
      serie1.Data.Add(data4);
      serie1.Data.Add(data5);
      serie1.Data.Add(data6);
      serie1.Data.Add(data7);
      serie1.Data.Add(data8);

      Serie serie2 = new Serie() { Naam = "Manufacturing" };
      data1 = new Data() { Value = 24916 };
      data2 = new Data() { Value = 24064 };
      data3 = new Data() { Value = 29742 };
      data4 = new Data() { Value = 29851 };
      data5 = new Data() { Value = 32490 };
      data6 = new Data() { Value = 30282 };
      data7 = new Data() { Value = 38121 };
      data8 = new Data() { Value = 40434 };
      serie2.Data.Add(data1);
      serie2.Data.Add(data2);
      serie2.Data.Add(data3);
      serie2.Data.Add(data4);
      serie2.Data.Add(data5);
      serie2.Data.Add(data6);
      serie2.Data.Add(data7);
      serie2.Data.Add(data8);

      Serie serie3 = new Serie() { Naam = "Sales & Distribution" };
      data1 = new Data() { Value = 11744 };
      data2 = new Data() { Value = 17722 };
      data3 = new Data() { Value = 16005 };
      data4 = new Data() { Value = 19771 };
      data5 = new Data() { Value = 20185 };
      data6 = new Data() { Value = 24377 };
      data7 = new Data() { Value = 32147 };
      data8 = new Data() { Value = 39387 };
      serie3.Data.Add(data1);
      serie3.Data.Add(data2);
      serie3.Data.Add(data3);
      serie3.Data.Add(data4);
      serie3.Data.Add(data5);
      serie3.Data.Add(data6);
      serie3.Data.Add(data7);
      serie3.Data.Add(data8);

      Serie serie4 = new Serie() { Naam = "Project Development" };
      data1 = new Data() { Value = 0 };
      data2 = new Data() { Value = 0 };
      data3 = new Data() { Value = 7988 };
      data4 = new Data() { Value = 12169 };
      data5 = new Data() { Value = 15112 };
      data6 = new Data() { Value = 22452 };
      data7 = new Data() { Value = 34400 };
      data8 = new Data() { Value = 34227 };
      serie4.Data.Add(data1);
      serie4.Data.Add(data2);
      serie4.Data.Add(data3);
      serie4.Data.Add(data4);
      serie4.Data.Add(data5);
      serie4.Data.Add(data6);
      serie4.Data.Add(data7);
      serie4.Data.Add(data8);

      Serie serie5 = new Serie() { Naam = "Other" };
      data1 = new Data() { Value = 12908 };
      data2 = new Data() { Value = 5948 };
      data3 = new Data() { Value = 8105 };
      data4 = new Data() { Value = 11248 };
      data5 = new Data() { Value = 8989 };
      data6 = new Data() { Value = 11816 };
      data7 = new Data() { Value = 18274 };
      data8 = new Data() { Value = 18111 };
      serie5.Data.Add(data1);
      serie5.Data.Add(data2);
      serie5.Data.Add(data3);
      serie5.Data.Add(data4);
      serie5.Data.Add(data5);
      serie5.Data.Add(data6);
      serie5.Data.Add(data7);
      serie5.Data.Add(data8);

      List<Serie> series = new List<Serie>();
      series.Add(serie1);
      series.Add(serie2);
      series.Add(serie3);
      series.Add(serie4);
      series.Add(serie5);

      Grafiek grafiek1 = new Lijn(0, "Solar Employment Growth by Sector, 2010-2016", new As()
      { IsUsed = true, Titel = "Number of Employees" }, series);
      grafiek1.GebruikerId = 0;
      As xAs = new As() { IsUsed = true };

      Categorie cat1 = new Categorie("Apples");
      Categorie cat2 = new Categorie("Oranges");
      Categorie cat3 = new Categorie("Pears");
      Categorie cat4 = new Categorie("Grapes");
      Categorie cat5 = new Categorie("Bananas");

      xAs.Categorieen.Add(cat1);
      xAs.Categorieen.Add(cat2);
      xAs.Categorieen.Add(cat3);
      xAs.Categorieen.Add(cat4);
      xAs.Categorieen.Add(cat5);

      serie1 = new Serie() { Naam = "John" };
      data1 = new Data(5);
      data2 = new Data(3);
      data3 = new Data(4);
      data4 = new Data(7);
      data5 = new Data(2);
      serie1.Data.Add(data1);
      serie1.Data.Add(data2);
      serie1.Data.Add(data3);
      serie1.Data.Add(data4);
      serie1.Data.Add(data5);

      serie2 = new Serie() { Naam = "Jane" };
      data1 = new Data(2);
      data2 = new Data(-2);
      data3 = new Data(-3);
      data4 = new Data(2);
      data5 = new Data(1);
      serie2.Data.Add(data1);
      serie2.Data.Add(data2);
      serie2.Data.Add(data3);
      serie2.Data.Add(data4);
      serie2.Data.Add(data5);

      serie3 = new Serie() { Naam = "Joe" };
      data1 = new Data(3);
      data2 = new Data(4);
      data3 = new Data(4);
      data4 = new Data(-2);
      data5 = new Data(5);
      serie3.Data.Add(data1);
      serie3.Data.Add(data2);
      serie3.Data.Add(data3);
      serie3.Data.Add(data4);
      serie3.Data.Add(data5);

      List<Serie> series2 = new List<Serie>();
      series2.Add(serie1);
      series2.Add(serie2);
      series2.Add(serie3);

      Grafiek grafiek2 = new Bar(1, "Column chart with negative values",
         xAs, series2);
      grafiek2.GebruikerId = 0;
      serie1 = new Serie() { Naam = "Brands", ColorByPoint = true };
      data1 = new Data() { Naam = "Chrome", Value = 61.41, Sliced = true, Selected = false };
      data2 = new Data() { Naam = "Internet Explorer", Value = 11.84 };
      data3 = new Data() { Naam = "Firefox", Value = 10.85 };
      data4 = new Data() { Naam = "Edge", Value = 4.67 };
      data5 = new Data() { Naam = "Safari", Value = 4.18 };
      data6 = new Data() { Naam = "Other", Value = 7.05 };
      serie1.Data.Add(data1);
      serie1.Data.Add(data2);
      serie1.Data.Add(data3);
      serie1.Data.Add(data4);
      serie1.Data.Add(data5);
      serie1.Data.Add(data6);

      Grafiek grafiek3 = new Pie(2, "Browser market shares in January, 2018", serie1);
      grafiek3.GebruikerId = 0;
      context.Grafieken.Add(grafiek1);
      context.Grafieken.Add(grafiek2);
      context.Grafieken.Add(grafiek3);

      context.SaveChanges();
    }

    /*private void AddAlerts(Integratie2018Context context)
    {
       Alert a1 = new Alert()
       {
          ID = 0,
          Verzendwijze = "SMS",
          Type = "Trending",
          Veld = "Politieker",
          VeldWaarde = "Annick De Ridder",
          Percentage = 0,
          Gebruiker = context.Gebruikers.Find(0)
       };
       context.Alerts.Add(a1);

       Alert a2 = new Alert()
       {
          ID = 1,
          Verzendwijze = "Applicatie",
          Type = "Aantal",
          Veld = "Politieker",
          VeldWaarde = "Annick De Ridder",
          Percentage = 5,
          Gebruiker = context.Gebruikers.Find(0)
       };
       context.Alerts.Add(a2);

       Alert a3 = new Alert()
       {
          ID = 2,
          Verzendwijze = "E-Mail",
          Type = "Trending",
          Veld = "Politieker",
          VeldWaarde = "Annick De Ridder",
          Percentage = 0,
          Gebruiker = context.Gebruikers.Find(1)
       };
       context.Alerts.Add(a3);

       Alert a4 = new Alert()
       {
          ID = 3,
          Verzendwijze = "Browser",
          Type = "Aantal",
          Veld = "Politieker",
          VeldWaarde = "Annick De Ridder",
          Percentage = 5,
          Gebruiker = context.Gebruikers.Find(1)
       };
       context.Alerts.Add(a4);
    }*/
  }
}

