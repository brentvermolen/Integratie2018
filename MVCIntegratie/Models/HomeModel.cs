using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIntegratie.Models
{
   public class HomeModel
   {
      public List<Grafiek> Grafieken { get; set; }
      public List<Persoon> Personen { get; set; }
   }
}