using BL.Domain.ItemKlassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class JsonExport
   {
      public List<Bericht> Berichten { get; set; }

      public JsonExport(List<Bericht> Berichten)
      {
         this.Berichten = Berichten;
      }
      
      public string GetPolitiekersVanBericht()
      {
         string json = "[";

         foreach(Bericht bericht in Berichten)
         {
            foreach(Persoon persoon in bericht.Personen)
            {
               json += " { ";
               json += GetJsonString("id", bericht.ID.ToString()) + ",";
               json += GetJsonString("date", bericht.Datum.ToShortDateString()) + ",";
               json += GetJsonString("persoon", persoon.Naam) + ",";
               json += GetJsonString("retweet", bericht.Retweet.ToString());
               json += " },";
            }
         }

         int lastindex = json.LastIndexOf(",");
         json = json.Remove(lastindex, 1);

         json += "]";

         return json;
      }

      private string GetJsonString(string titel, string item)
      {
         return "\"" + titel + "\":" + "\"" + item + "\"";
      }
   }
}
