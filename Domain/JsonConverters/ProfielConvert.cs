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
   class ProfielConvert : JsonConverter
   {
      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         return reader.Value.ToString();
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         writer.WriteValue(value.ToString());
         writer.ToString();
      }
   }
}
