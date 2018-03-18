using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Text;

namespace DAL
{
   public class Integratie2018Initializer : DropCreateDatabaseIfModelChanges<Integratie2018Context>
   {
      protected override void Seed(Integratie2018Context context)
      {
         using (StreamReader sr = new StreamReader("C:\\Users\\Brent\\Documents\\School\\KDG\\2017-2018\\IntegratieProject\\PoC\\Temp\\File.json"))
         {
            string json = sr.ReadToEnd();

            List<string> jsonItems = GetJsonItems(json);

            int intTeller = 0;

            foreach (string str in jsonItems)
            {
               if (intTeller++ == 100)
               {
                  break;
               }

               Bericht bericht = JsonConvert.DeserializeObject<Bericht>(str);

               //Naam van de politieker verwijderen uit lijst met woorden
               foreach (string p in bericht.PolitiekerJson)
               {
                  if (bericht.WoordenJson.Contains(p.ToLower()))
                  {
                     bericht.WoordenJson.Remove(p.ToLower());
                  }
               }

               Persoon persoon = context.Personen.Find(string.Join(" ", bericht.PolitiekerJson));
               if (persoon == null)
               {
                  persoon = new Persoon(string.Join(" ", bericht.PolitiekerJson));
                  bericht.Politieker = persoon;
                  context.Personen.Add(persoon);
               }
               else
               {
                  bericht.Politieker = persoon;
               }
               bericht.Polariteit = bericht.Sentiment[0];
               bericht.Objectiviteit = bericht.Sentiment[1];

               bericht.Woorden = new List<Woord>();
               bericht.Urls = new List<Url>();
               bericht.Mentions = new List<Mention>();
               bericht.Hashtags = new List<Hashtag>();

               foreach (string t in bericht.WoordenJson)
               {
                  Woord woord = context.Woorden.Find(t);
                  if (woord == null)
                  {
                     woord = new Woord() { Tekst = t };
                     bericht.Woorden.Add(woord);
                     context.Woorden.Add(woord);
                  }
                  else
                  {
                     bericht.Woorden.Add(woord);
                  }
               }
               foreach (string t in bericht.UrlsJson)
               {
                  Url url = context.Urls.Find(t);
                  if (url == null)
                  {
                     url = new Url() { Tekst = t };
                     bericht.Urls.Add(url);
                     context.Urls.Add(url);
                  }
                  else
                  {
                     bericht.Urls.Add(url);
                  }
               }
               foreach (string t in bericht.MentionsJson )
               {
                  Mention mention = context.Mentions.Find(t);
                  if (mention == null)
                  {
                     mention = new Mention() { Tekst = t };
                     bericht.Mentions.Add(mention);
                     context.Mentions.Add(mention);
                  }
                  else
                  {
                     bericht.Mentions.Add(mention);
                  }
               }
               foreach (string t in bericht.HashtagsJson)
               {
                  Hashtag hashtag = context.Hashtags.Find(t);
                  if (hashtag == null)
                  {
                     hashtag = new Hashtag() { Tekst = t };
                     bericht.Hashtags.Add(hashtag);
                     context.Hashtags.Add(hashtag);
                  }
                  else
                  {
                     bericht.Hashtags.Add(hashtag);
                  }
               }

               if (context.Berichten.Find(bericht.ID) == null)
               {
                  context.Berichten.Add(bericht);
               }
            }
         }

         context.SaveChanges();
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
