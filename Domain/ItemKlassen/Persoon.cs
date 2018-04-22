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
      public Persoon() { Berichten = new List<Bericht>(); }

      [Key]
      public int ID { get; set; }
      public string Naam { get; set; }
      
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

      public override string ToString()
      {
         return Naam;
      }
   }
}
