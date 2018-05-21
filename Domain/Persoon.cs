using BL.Domain.JsonConverters;
using BL.Domain.PersoonKlassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class Persoon : Item
   {
      public Persoon() { Berichten = new List<Bericht>(); }

      [Key]
      public int ID { get; set; }
      [JsonProperty("full_name")]
      public string Naam { get; set; }
      [JsonProperty("district")]
      public string District { get; set; }
      [JsonProperty("gender")]
      public string Geslacht { get; set; }
      [JsonProperty("twitter")]
      public string Twitter { get; set; }
      [JsonProperty("site")]
      public string Website { get; set; }
      [JsonProperty("dateOfBirth")]
      public DateTime Geboortedatum { get; set; }
      [JsonProperty("facebook")]
      public string Facebook { get; set; }
      [JsonProperty("organisation")]
      [JsonConverter(typeof(OrganisatieConvert))]
      public Organisatie Organisatie { get; set; }
      [JsonProperty("postal_code")]
      public string Postcode { get; set; }

      public bool Disabled { get; set; }

      public int DeelplatformID { get; set; }
      public Deelplatform Deelplatform { get; set; }

      public ICollection<Bericht> Berichten { get; set; }

      public override bool Equals(object obj)
      {
         if (obj.GetType() != GetType())
         {
            return false;
         }

         Persoon p = (Persoon)obj;

         if (p.Naam.Equals(Naam))
         {
            return true;
         }

         return false;
      }

      public List<Grafiek> Grafieken { get; set; }

      public override string ToString()
      {
         return Naam;
      }
   }
}
