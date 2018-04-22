using BL.Domain.BerichtKlassen;
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
      public static string GetPolitiekersVanBerichten(List<Bericht> berichten)
      {
         string json = "[";

         foreach(Bericht bericht in berichten)
         {
            foreach(Persoon persoon in bericht.Personen)
            {
               json += " { ";
               json += GetJsonString("id", bericht.ID.ToString()) + ",";
               json += GetJsonString("date", bericht.Datum.ToShortDateString()) + ",";
               json += GetJsonString("bron", bericht.Bron.ToString()) + ",";
               json += GetJsonString("politieker", persoon.Naam);
               json += " },";
            }
         }

         int lastindex = json.LastIndexOf(",");
         json = json.Remove(lastindex, 1);

         json += "]";

         return json;
      }

      public static string Lijst(List<Bericht> berichten)
      {
         return JsonConvert.SerializeObject(berichten);
      }

      private static string GetJsonString(string titel, string item)
      {
         return "\"" + titel + "\":" + "\"" + item + "\"";
      }
   }
}
