using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using BL.Domain.ItemKlassen;
using BL.Domain.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Domain
{
   public class Grafiek
   {
      public Grafiek()
      {
         xAs = new As();
         yAs = new As();
         Legende = new Legende();
         PlotOptions = new PlotOptions();
         Series = new List<Serie>();
         isDefault = true;
      }


      [Key]
      public int ID { get; set; }
      [JsonProperty("chart")]
      [NotMapped]
      public Chart Chart { get; set; }
      public string Titel { get; set; }
      [NotMapped]
      public string Tooltip { get; set; }
      [JsonProperty("xAxis")]
      public virtual As xAs { get; set; }
      public virtual As yAs { get; set; }
      [NotMapped]
      public bool Credits { get; set; }
      [NotMapped]
      public Legende Legende { get; set; }
      [NotMapped]
      public PlotOptions PlotOptions { get; set; }
      public int GebruikerId { get; set; }
      public Gebruiker Gebruiker { get; set; }

      public virtual List<Serie> Series { get; set; }

      public bool isDefault { get; set; }

      public string GetBoolString(bool boolean)
      {
         if (boolean)
         {
            return "true";
         }

         return "false";
      }
   }
}