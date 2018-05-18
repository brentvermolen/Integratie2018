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
         Personen = new List<Persoon>();
         isDefault = false;
         Categorieen = new List<Categorie>();
         Order = -1;
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
      [NotMapped]
      public virtual As xAs { get; set; }
      [NotMapped]
      public virtual As yAs { get; set; }
      [NotMapped]
      public bool Credits { get; set; }
      [NotMapped]
      public Legende Legende { get; set; }
      [NotMapped]
      public PlotOptions PlotOptions { get; set; }
      public int GebruikerId { get; set; }
      public Gebruiker Gebruiker { get; set; }
      
      [NotMapped]
      public List<Serie> Series { get; set; }
      
      public virtual List<Persoon> Personen { get; set; }
      public double PointStart { get; set; }
      public string ContentType { get; set; }
      public int AantalSeries { get; set; }
      public virtual List<Categorie> Categorieen { get; set; }
      public string TitelXAs { get; set; }
      public string TitelYAs { get; set; }

      public int Order { get; set; }

      public bool isDefault { get; set; }

      public Deelplatform Deelplatform { get; set; }

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