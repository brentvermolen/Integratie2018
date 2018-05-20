using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class Deelplatform
   {
      public Deelplatform()
      {
         Gebruikers = new List<Gebruiker>();
         Admins = new List<Gebruiker>();

         FAQs = new List<FAQ>();
         Contacts = new List<Contact>();
      }

      [Key]
      public int ID { get; set; }
      public string Naam { get; set; }

      public virtual List<Gebruiker> Gebruikers { get; set; }
      public virtual List<Gebruiker> Admins { get; set; }

      public List<FAQ> FAQs { get; set; }
      public List<Contact> Contacts { get; set; }

      public List<Persoon> Personen { get; set; }
   }
}
