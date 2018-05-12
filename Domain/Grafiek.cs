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
         Chart = new Chart() { Type = "normal" };
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
    public Chart Chart { get; set; }
    public string Titel { get; set; }
    public string Tooltip { get; set; }
    [JsonProperty("xAxis")]
    public virtual As xAs { get; set; }
    public virtual As yAs { get; set; }
    public bool Credits { get; set; }
    public Legende Legende { get; set; }
    public PlotOptions PlotOptions { get; set; }
    public int GebruikerId { get; set; }
    public Gebruiker Gebruiker { get; set; }

      public virtual List<Serie> Series { get; set; }
      public Gebruiker Gebruiker { get; set; }
      public int GebruikerID { get; set; }

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