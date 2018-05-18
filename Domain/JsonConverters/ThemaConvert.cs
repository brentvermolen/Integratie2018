using BL.Domain.BerichtKlassen;
using DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.JsonConverters
{
   public class ThemaConvert : JsonConverter
   {
      private static BerichtRepository repo = new BerichtRepository();
      private static List<Thema> Themas = new List<Thema>();

      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Thema thema = Themas.FirstOrDefault(u => u.Tekst.Equals(reader.Value.ToString()));
         if (thema == null)
         {
            thema = new Thema() { ID = Themas.Count, Tekst = reader.Value.ToString() };
            Themas.Add(thema);
         }
         return thema;
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         JObject jo = new JObject();
      }
   }
}
