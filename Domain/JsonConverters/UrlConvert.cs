using BL.Domain.BerichtKlassen;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.JsonConverters
{
   public class UrlConvert : JsonConverter
   {
      private static List<Url> Urls = new List<Url>();

      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Url url = Urls.FirstOrDefault(u => u.Tekst.Equals(reader.Value.ToString()));
         if (url == null)
         {
            url = new Url() { ID = Urls.Count, Tekst = reader.Value.ToString() };
            Urls.Add(url);
         }
         return url;
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         Url url = (Url)value;
         writer.WriteValue(url.Tekst);
      }
   }
}
