using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.AlertKlassen
{
   public class AlertResultaat
   {
      public Alert Alert { get; set; }
      public Gebruiker Gebruiker { get; set; }
      public string Resultaat { get; set; }
   }
}
