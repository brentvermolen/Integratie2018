using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.PersoonKlassen
{
   public class Organisatie
   {
      [Key]
      public int ID { get; set; }
      public string Naam { get; set; }

      public List<Persoon> Personen { get; set; }

      public override string ToString()
      {
         return Naam;
      }
   }
}
