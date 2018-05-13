using BL.Domain;
using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCIntegratie.Models
{
   public class NieuweGrafiekModel
   {
      public NieuweGrafiekModel()
      {
         IsGewijzigd = false;
         GewijzigdType = "";
      }

      public Grafiek Line { get; set; }
      public Grafiek Bar { get; set; }
      public Grafiek Pie { get; set; }
      public bool IsGewijzigd { get; set; }
      public string GewijzigdType { get; set; }
      public List<Persoon> Personen { get; set; }
   }
}
