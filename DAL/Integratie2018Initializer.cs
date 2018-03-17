using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Text;

namespace DAL
{
   public class Integratie2018Initializer : DropCreateDatabaseAlways<Integratie2018Context>
   {
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

      protected override void Seed(Integratie2018Context context)
      {
         using (StreamReader sr = new StreamReader("C:\\Users\\Brent\\Documents\\School\\KDG\\2017-2018\\IntegratieProject\\PoC\\Temp\\File.json"))
         {
            string json = sr.ReadToEnd();

            List<string> jsonItems = GetJsonItems(json);

            foreach (string str in jsonItems)
            {
               Bericht bericht = JsonConvert.DeserializeObject<Bericht>(str);

               //Naam van de politieker verwijderen uit lijst met woorden
               foreach (string p in bericht.PolitiekerJson)
               {
                  if (bericht.WoordenJson.Contains(p.ToLower()))
                  {
                     bericht.WoordenJson.Remove(p.ToLower());
                  }
               }

               bericht.Politieker = string.Join(" ", bericht.PolitiekerJson);
               bericht.Polariteit = bericht.Sentiment[0];
               bericht.Objectiviteit = bericht.Sentiment[1];
               bericht.Woorden = string.Join(";", bericht.WoordenJson);
               bericht.Urls = string.Join(";", bericht.UrlsJson);
               bericht.Hashtags = string.Join(";", bericht.HashtagsJson);
               bericht.Mentions = string.Join(";", bericht.MentionsJson);

               if (context.Berichten.Find(bericht.ID) == null)
               {
                  context.Berichten.Add(bericht);
               }
            }
         }

         context.SaveChanges();
      }
   }
}
