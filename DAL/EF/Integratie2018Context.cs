using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
   public class Integratie2018Context : DbContext
   {
      public Integratie2018Context() : base("integratie2018DB")
      {
         Database.SetInitializer(new Integratie2018Initializer());
         try
         {
            Database.Initialize(false);
         }catch(Exception e)
         {
            e.ToString();
         }
      }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Bericht>()
            .HasMany(b => b.Woorden)
            .WithMany(t => t.Berichten);
         modelBuilder.Entity<Bericht>()
            .HasMany(b => b.Urls)
            .WithMany(u => u.Berichten);
         modelBuilder.Entity<Bericht>()
            .HasMany(b => b.Mentions)
            .WithMany(m => m.Berichten);
         modelBuilder.Entity<Bericht>()
            .HasMany(b => b.Hashtags)
            .WithMany(h => h.Berichten);

         base.OnModelCreating(modelBuilder);
      }

      public DbSet<Synchronize> Sync { get; set; }

      public DbSet<Bericht> Berichten { get; set; }
      public DbSet<Woord> Woorden { get; set; }
      public DbSet<Url> Urls { get; set; } 
      public DbSet<Mention> Mentions { get; set; }
      public DbSet<Hashtag> Hashtags { get; set; }
      public DbSet<Thema> Themas { get; set; }

      public DbSet<Persoon> Personen { get; set; }

      public DbSet<Gebruiker> Gebruikers { get; set; }

      public DbSet<Alert> Alerts { get; set; }
   }

   public class Synchronize
   {
      [Key]
      public int ID { get; set; }
      public DateTime Latest { get; set; }
      [NotMapped]
      public Integratie2018Context Context { get; set; }

      public void Start()
      {
         ApiCallAsync(Context);
      }

      private string GetMaand(int maand)
      {
         switch (maand)
         {
            case 1:
               return "Januari";
            case 2:
               return "Februari";
            case 3:
               return "Maart";
            case 4:
               return "April";
            case 5:
               return "Mei";
            case 6:
               return "Juni";
            case 7:
               return "Juli";
            case 8:
               return "Augustus";
            case 9:
               return "September";
            case 10:
               return "Oktober";
            case 11:
               return "November";
            case 12:
               return "December";
         }

         return "";
      }

      public string GetSince()
      {
         return "\"since\":\"" + Latest.Day + " " + GetMaand(Latest.Month) + " " + Latest.Year + " " + Latest.TimeOfDay + "\"";
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

            StringContent content = new StringContent("{" + GetSince() + "}", System.Text.Encoding.UTF8, "application/json");
            Latest = DateTime.Now;
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();

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
         }
         catch (Exception e)
         {
            e.ToString();
            BerichtenJson = null;
         }

         BerichtenJson.ToString();

         context.Berichten.AddRange(BerichtenJson.berichten);

         try
         {
            context.SaveChanges();
         }
         catch (Exception ex)
         {
            ex.ToString();
         }
         return BerichtenJson.berichten;
      }
   }
}
