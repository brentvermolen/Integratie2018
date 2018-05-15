using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekKlassen
{
   public class Categorie
   {
      public Categorie() { }

      public Categorie(string tekst)
      {
         Tekst = tekst;
         Grafieken = new List<Grafiek>();
      }

      [Key]
      public int ID { get; set; }
      public string Tekst { get; set; }

      public virtual List<Grafiek> Grafieken { get; set; }

      public override string ToString()
      {
         return Tekst;
      }
   }
}
