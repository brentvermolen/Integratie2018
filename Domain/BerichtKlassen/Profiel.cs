using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.BerichtKlassen
{
   public class Profiel
   {
      public Profiel() { }
      
      [JsonProperty("gender")]
      public string Geslacht { get; set; }
      [JsonProperty("age")]
      public string Leeftijd { get; set; }
      [JsonProperty("education")]
      public string Scholing { get; set; }
      [JsonProperty("language")]
      public string Taal { get; set; }
      [JsonProperty("personality")]
      public string Persoonlijkheid { get; set; }
   }
}
