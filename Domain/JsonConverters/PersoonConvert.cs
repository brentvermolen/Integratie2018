using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BL.Domain.JsonConverters
{
   public class PersoonConvert : JsonConverter
   {
      private static List<Persoon> Personen = new List<Persoon>();

      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Persoon persoon = Personen.Find(p => p.Naam == reader.Value.ToString());
         if (persoon == null)
         {
            persoon = new Persoon() { ID = Personen.Count, Naam = reader.Value.ToString(), Geboortedatum = new DateTime(1900, 1, 1), Disabled = true, DeelplatformID = 1 };
            Personen.Add(persoon);
         }
         
         return persoon;
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         /*Persoon persoon = (Persoon)value;

         JProperty jp = new JProperty("person", persoon.Naam);

         jp.ToString();

         JObject jObject = JObject.Load(writer);*/
      }
   }
}
