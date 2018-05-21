using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class Contact
   {
      [Key]
      public int ID { get; set; }
      public string Email { get; set; }
      public string Naam { get; set; }
      public string Onderwerp { get; set; }
      public string Bericht { get; set; }

      public int DeelplatformID { get; set; }
      public Deelplatform Deelplatform { get; set; }
   }
}
