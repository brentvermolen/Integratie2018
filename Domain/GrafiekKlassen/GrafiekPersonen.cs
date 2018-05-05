using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekKlassen
{
   public class GrafiekPersonen
   {
      public Grafiek Grafiek { get; set; }
      public List<Persoon> Personen { get; set; }
   }
}
