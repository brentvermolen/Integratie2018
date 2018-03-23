using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class Gebruiker
   {
      public int ID { get; set; }
      public string Naam { get; set; }

      IEnumerable<Alert> Alerts { get; set; }

      public override string ToString()
      {
         return Naam;
      }
   }
}
