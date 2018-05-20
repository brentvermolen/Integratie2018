using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIntegratie.Models
{
   public class AdminModel
   {
      public List<FAQ> FAQ { get; set; }
      public List<Gebruiker> Gebruikers { get; set; }
      public List<Deelplatform> Deelplatformen { get; set; }
      public List<Persoon> Personen { get; set; }
   }
}