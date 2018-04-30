using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekKlassen
{
   public class NieuweGrafiekModel
   {
      public Grafiek Line { get; set; }
      public Grafiek Bar { get; set; }
      public Grafiek Pie { get; set; }

      public List<Persoon> Personen { get; set; }
   }
}
