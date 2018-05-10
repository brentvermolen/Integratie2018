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
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Postcode { get; set; }
        public string Beveiligingsvraag { get; set; }
        public string Antwoord { get; set; }


        IEnumerable<Alert> Alerts { get; set; }

      public override string ToString()
      {
         return Voornaam;
      }
   }
}
