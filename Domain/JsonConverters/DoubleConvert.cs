using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.JsonConverters
{
   public class DoubleConvert : JsonConverter
   {
      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         try
         {
            double d = double.Parse(reader.Value.ToString());
            return d;
         }catch(Exception e)
         {
            return 0;
         }
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      { 

      }
   }
}
