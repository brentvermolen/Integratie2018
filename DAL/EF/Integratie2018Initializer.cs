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
   public class Integratie2018Initializer  : DropCreateDatabaseAlways<Integratie2018Context>
   {
      protected override void Seed(Integratie2018Context context)
      {
         ApiCallAsync(context);

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

            StringContent content = new StringContent("{\"since\":\"20 April 2017 00:00:00\"}", System.Text.Encoding.UTF8, "application/json");
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
         BerichtenClass BerichtenJson;
         try
         {
             BerichtenJson = JsonConvert.DeserializeObject<BerichtenClass>(json);
         }catch(Exception e)
         {
            e.ToString();
            BerichtenJson = null;
         }

         BerichtenJson.ToString();

         context.Berichten.AddRange(BerichtenJson.berichten);

         try
         {
            context.SaveChanges();
         }catch(Exception ex)
         {
            ex.ToString();
         }
         return BerichtenJson.berichten;
      }

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
