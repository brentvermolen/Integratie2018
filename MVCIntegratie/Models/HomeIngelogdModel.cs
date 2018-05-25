using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIntegratie.Models
{
   public class HomeIngelogdModel
   {
      public List<Grafiek> Grafieken { get; set; }
      public Gebruiker Gebruiker { get; set; }
   }
}