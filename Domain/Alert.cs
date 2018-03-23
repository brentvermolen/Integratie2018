using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class Alert
   {
      public int ID { get; set; }
      public string Verzendwijze { get; set; }
      public int Percentage { get; set; }
      public Gebruiker Gebruiker { get; set; }
      public string Type { get; set; }
      public string Veld { get; set; }
      public string VeldWaarde { get; set; }

      public override string ToString()
      {
         return ID.ToString();
      }
   }
}
