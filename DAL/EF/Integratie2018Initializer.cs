using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Integratie2018Initializer : DropCreateDatabaseAlways<Integratie2018Context>
   {
      protected override void Seed(Integratie2018Context context)
      {
         var test = ApiCallAsync(context);

         AddGebruikers(context);

         AddAlerts(context);

         context.SaveChanges();
      }

      //TODO: Timer zetten, elk uur inladen

      private static readonly HttpClient client = new HttpClient();

      public async Task ApiCallAsync(Integratie2018Context context)
      {
         try
         {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            {
               CharSet = "utf-8"
            });

            StringContent content = new StringContent("{\"since\":\"19 April 2018 00:00:00\"}", System.Text.Encoding.UTF8, "application/json");
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            {
               CharSet = "utf-8"
            };
            content.Headers.Add("X-API-Key", "aEN3K6VJPEoh3sMp9ZVA73kkr");

            HttpResponseMessage response = await client.PostAsync("http://kdg.textgain.com/query", content);

            string responseString = await response.Content.ReadAsStringAsync();
            responseString.ToString();

            AddBerichten(responseString, context);
         }
         catch (Exception e)
         {
            e.ToString();
         }
      }

      private class BerichtenClass
      {
         [JsonProperty("berichten")]
         public List<Bericht> berichten { get; set; }
      }

      public IEnumerable<Bericht> AddBerichten(string json, Integratie2018Context context)
      {
         json = "{ \"berichten\": " + json + " }";
         json = json.Replace("\"geo\": false", "\"geo\": [0, 0]");

         BerichtenClass BerichtenJson = JsonConvert.DeserializeObject<BerichtenClass>(json);

         BerichtenJson.ToString();

         try
         {
            foreach (Bericht bericht in BerichtenJson.berichten)
            {
               if (context.Berichten.Find(bericht.ID) != null)
               {
                  continue;
               }

               try
               {
                  bericht.Longtitude = bericht.Geo[0];
                  bericht.Latitude = bericht.Geo[1];
               }
               catch (Exception ex)
               {
                  bericht.Longtitude = 0;
                  bericht.Latitude = 0;
               }

               try
               {
                  bericht.Polariteit = bericht.Sentiment[0];
                  bericht.Objectiviteit = bericht.Sentiment[1];
               }
               catch (Exception ex)
               {
                  bericht.Polariteit = 0;
                  bericht.Objectiviteit = 0;
               }

               foreach (string p in bericht.PersonenJson)
               {
                  Persoon persoon = context.Personen.Find(p);
                  if (persoon == null)
                  {
                     persoon = new Persoon();
                     persoon.Naam = p;
                     context.Personen.Add(persoon);
                  }
                  persoon.Berichten.Add(bericht);
               }

               /*foreach (string t in bericht.WoordenJson)
               {
                  Woord woord = context.Woorden.FirstOrDefault(f => f.Tekst.Equals(t));
                  if (woord == null)
                  {
                     woord = new Woord() { Tekst = t };
                     context.Woorden.Add(woord);
                  }
                  bericht.Woorden.Add(woord);
               }

               foreach (string t in bericht.UrlsJson)
               {
                  Url url = context.Urls.FirstOrDefault(f => f.Tekst.Equals(t));
                  if (url == null)
                  {
                     url = new Url() { Tekst = t };
                     context.Urls.Add(url);
                  }
                  bericht.Urls.Add(url);
               }

               foreach (string t in bericht.MentionsJson)
               {
                  Mention mention = context.Mentions.FirstOrDefault(f => f.Tekst.Equals(t));
                  if (mention == null)
                  {
                     mention = new Mention() { Tekst = t };
                     context.Mentions.Add(mention);
                  }
                  bericht.Mentions.Add(mention);
               }
               
               foreach (string t in bericht.HashtagsJson)
               {
                  Hashtag hashtag = context.Hashtags.FirstOrDefault(f => f.Tekst.Equals(t));
                  if (hashtag == null)
                  {
                     hashtag = new Hashtag() { Tekst = t };
                     context.Hashtags.Add(hashtag);
                  }

                  bericht.Hashtags.Add(hashtag);
               }*/

               if (context.Berichten.Find(bericht.ID) == null)
               {
                  context.Berichten.Add(bericht);
               }

               bericht.ToString();
            }
         }catch(Exception e) { }

         context.SaveChanges();
         return BerichtenJson.berichten;
      }


      /*
      public List<string> GetJsonItems(string ExampleJSON)
      {
         int BracketCount = -1;
         List<string> JsonItems = new List<string>();
         StringBuilder Json = new StringBuilder();

         foreach (char c in ExampleJSON)
         {
            if (BracketCount == -1 && c == '{')
            {
               Json = new StringBuilder();
            }

            if (c == '{')
               ++BracketCount;
            else if (c == '}')
               --BracketCount;
            Json.Append(c);

            if (BracketCount == -1 && c == '}')
            {
               JsonItems.Add(Json.ToString());
            }
         }
         return JsonItems;
      }*/

      private void AddAlerts(Integratie2018Context context)
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
      }

      private void AddGebruikers(Integratie2018Context context)
      {
         Gebruiker g1 = new Gebruiker()
         {
            ID = 0,
            Naam = "Eddy"
         };
         context.Gebruikers.Add(g1);

         Gebruiker g2 = new Gebruiker()
         {
            ID = 1,
            Naam = "Jan"
         };
         context.Gebruikers.Add(g2);
      }
   }
}
