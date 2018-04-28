using BL.Domain.GrafiekKlassen;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
      }

      [Key]
      public string ID { get; set; }
      public Chart Chart { get; set; }
      public string Titel { get; set; }
      public string Subtitel { get; set; }
      public string Tooltip { get; set; }
      public As xAs { get; set; }
      public As yAs { get; set; }
      public bool Credits { get; set; }
      public Legende Legende { get; set; }
      public PlotOptions PlotOptions { get; set; }
      public List<Serie> Series { get; set; }

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