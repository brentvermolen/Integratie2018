using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class Deelplatform
   {
      public int ID { get; set; }
      public string Naam { get; set; }

      public List<Gebruiker> Gebruikers { get; set; }
      public List<FAQ> FAQs { get; set; }
   }
}
