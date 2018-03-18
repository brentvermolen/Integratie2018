using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.ItemKlassen
{
   public class Persoon : Item
   {
      public Persoon() { }

      public Persoon(string Naam)
      {
         this.Naam = Naam;
      }

      [Key]
      public string Naam { get; set; }
      
      public ICollection<Bericht> Berichten { get; set; }

      public override string ToString()
      {
         return Naam;
      }
   }
}
