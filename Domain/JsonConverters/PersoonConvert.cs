using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
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
   public class PersoonConvert : JsonConverter
   {
      private static BerichtRepository repo = new BerichtRepository();
      private static List<Persoon> Personen = repo.ReadPersonen().ToList();

      public override bool CanConvert(Type objectType)
      {
         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         Persoon persoon = Personen.FirstOrDefault(p => p.Naam.Equals(reader.Value.ToString()));
         if (persoon == null)
         {
            persoon = new Persoon() { ID = Personen.Count, Naam = reader.Value.ToString() };
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
