using BL.Domain.BerichtKlassen;
using DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class HashtagConvert : JsonConverter
   {
      private static BerichtRepository repo = new BerichtRepository();
      private static List<Hashtag> Hashtags = repo.ReadHashtags().ToList();

      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Hashtag hashtag = Hashtags.FirstOrDefault(h => h.Tekst.Equals(reader.Value.ToString()));
         if (hashtag == null)
         {
            hashtag = new Hashtag() { ID = Hashtags.Count, Tekst = reader.Value.ToString() };
            Hashtags.Add(hashtag);
         }
         return hashtag;
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         Hashtag hashtag = (Hashtag)value;
         writer.WriteValue(hashtag.Tekst);
      }
   }
}
