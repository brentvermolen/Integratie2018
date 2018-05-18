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
   public class WoordenConvert : JsonConverter
   {
      private static BerichtRepository repo = new BerichtRepository();
      private static List<Woord> Woorden = repo.ReadWoorden().ToList();

      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Woord woord = Woorden.Find(w => w.Tekst.Equals(reader.Value.ToString()));
         if (woord == null)
         {
            woord = new Woord() { ID = Woorden.Count, Tekst = reader.Value.ToString() };
            Woorden.Add(woord);
         }

         return woord;
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         Woord woord = (Woord)value;
         writer.WriteValue(woord.Tekst);
      }
   }
}
