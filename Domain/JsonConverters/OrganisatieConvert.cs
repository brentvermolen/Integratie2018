using BL.Domain.PersoonKlassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BL.Domain.JsonConverters
{
   public class OrganisatieConvert : JsonConverter
   {
      private static List<Organisatie> Organisaties = new List<Organisatie>();

      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Organisatie organisatie = Organisaties.Find(m => m.Naam.Equals(reader.Value.ToString()));
         if (organisatie == null)
         {
            organisatie = new Organisatie() { Naam = reader.Value.ToString() };
            Organisaties.Add(organisatie);
         }
         return organisatie;
      }

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         Organisatie organisatie = (Organisatie)value;
         writer.WriteValue(organisatie.Naam);
      }
   }
}
