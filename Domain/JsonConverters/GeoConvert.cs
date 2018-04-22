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
         double d = double.Parse(reader.Value.ToString());
         return d;
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         JObject jo = new JObject();

         switch (writer.Path)
         {
            case "[0].geo":
               jo.Add("longtitude", value.ToString());
               break;
            case "[0].geo[0]":
               jo.Add("latitude", value.ToString());
               break;
            case "[0].sentiment":
               jo.Add("polariteit", value.ToString());
               break;
            case "[0].sentiment[0]":
               jo.Add("objectiviteit", value.ToString());
               break;
         }
         jo.WriteTo(writer);
      }
   }
}
