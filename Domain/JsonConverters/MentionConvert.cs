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
   public class MentionConvert : JsonConverter
   {
      private static List<Mention> Mentions = new List<Mention>();

      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Mention mention = Mentions.FirstOrDefault(m => m.Tekst.Equals(reader.Value.ToString()));
         if (mention == null)
         {
            mention = new Mention() { ID = Mentions.Count, Tekst = reader.Value.ToString() };
            Mentions.Add(mention);
         }
         return mention;
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         Mention mention = (Mention)value;
         writer.WriteValue(mention.Tekst);
      }
   }
}
