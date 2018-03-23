using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
         }catch(Exception e) { }
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

      public DbSet<Bericht> Berichten { get; set; }
      public DbSet<Woord> Woorden { get; set; }
      public DbSet<Url> Urls { get; set; } 
      public DbSet<Mention> Mentions { get; set; }
      public DbSet<Hashtag> Hashtags { get; set; }

      public DbSet<Persoon> Personen { get; set; }

      public DbSet<Gebruiker> Gebruikers { get; set; }

      public DbSet<Alert> Alerts { get; set; }
      

      public IEnumerable<Bericht> AddBerichten(int aantal, string vanPersoon = "")
      {
         List<Bericht> berichten = new List<Bericht>();

         using (StreamReader sr = new StreamReader("C:\\Users\\Brent\\Documents\\School\\KDG\\2017-2018\\IntegratieProject\\PoC\\Temp\\File.json"))
         {
            string json = sr.ReadToEnd();

            List<string> jsonItems = GetJsonItems(json);

            int intTeller = 0;

            foreach (string str in jsonItems)
            {
               if (vanPersoon.Equals(""))
               {
                  if (intTeller++ == aantal)
                  {
                     break;
                  }
               }

               Bericht bericht = JsonConvert.DeserializeObject<Bericht>(str);

               if (Berichten.Find(bericht.ID) != null)
               {
                  continue;
               }

               Persoon persoon = Personen.Find(string.Join(" ", bericht.PolitiekerJson));
               if (persoon == null)
               {
                  persoon = new Persoon(string.Join(" ", bericht.PolitiekerJson));
                  bericht.Politieker = persoon;
                  Personen.Add(persoon);
               }
               else
               {
                  bericht.Politieker = persoon;
               }
               bericht.Polariteit = bericht.Sentiment[0];
               bericht.Objectiviteit = bericht.Sentiment[1];

               /*bericht.Woorden = new List<Woord>();
               bericht.Urls = new List<Url>();
               bericht.Mentions = new List<Mention>();
               bericht.Hashtags = new List<Hashtag>();

               foreach (string t in bericht.WoordenJson)
               {
                  Woord woord = Woorden.FirstOrDefault(f => f.Tekst.Equals(t));
                  if (woord == null)
                  {
                     woord = new Woord() { Tekst = t };
                     bericht.Woorden.Add(woord);
                     Woorden.Add(woord);
                  }
                  else
                  {
                     bericht.Woorden.Add(woord);
                  }
               }
               foreach (string t in bericht.UrlsJson)
               {
                  Url url = Urls.FirstOrDefault(f => f.Tekst.Equals(t));
                  if (url == null)
                  {
                     url = new Url() { Tekst = t };
                     bericht.Urls.Add(url);
                     Urls.Add(url);
                  }
                  else
                  {
                     bericht.Urls.Add(url);
                  }
               }
               foreach (string t in bericht.MentionsJson)
               {
                  Mention mention = Mentions.FirstOrDefault(f => f.Tekst.Equals(t));
                  if (mention == null)
                  {
                     mention = new Mention() { Tekst = t };
                     bericht.Mentions.Add(mention);
                     Mentions.Add(mention);
                  }
                  else
                  {
                     bericht.Mentions.Add(mention);
                  }
               }
               foreach (string t in bericht.HashtagsJson)
               {
                  Hashtag hashtag = Hashtags.FirstOrDefault(f => f.Tekst.Equals(t));
                  if (hashtag == null)
                  {
                     hashtag = new Hashtag() { Tekst = t };
                     bericht.Hashtags.Add(hashtag);
                     Hashtags.Add(hashtag);
                  }
                  else
                  {
                     bericht.Hashtags.Add(hashtag);
                  }
               }*/

               if (Berichten.Find(bericht.ID) == null)
               {
                  if (!vanPersoon.Equals(""))
                  {
                     if (vanPersoon.Equals(persoon.Naam))
                     {
                        if (intTeller++ == aantal)
                        {
                           break;
                        }
                     }
                  }

                  berichten.Add(bericht);
                  Berichten.Add(bericht);
               }
            }
         }

         SaveChanges();
         return berichten;
      }

      public List<string> GetJsonItems(string ExampleJSON)
      {
         int BracketCount = -1;
         List<string> JsonItems = new List<string>();
         StringBuilder Json = new StringBuilder();

         foreach (char c in ExampleJSON)
         {
            if (BracketCount == 0 && c == '{')
            {
               Json = new StringBuilder();
            }

            if (c == '{')
               ++BracketCount;
            else if (c == '}')
               --BracketCount;
            Json.Append(c);

            if (BracketCount == 0 && c == '}')
            {
               JsonItems.Add(Json.ToString());
            }
         }
         return JsonItems;
      }
   }
}
