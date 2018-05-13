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
         Assen = new List<As>();
      }

      [Key]
      public int ID { get; set; }
      public string Tekst { get; set; }

      public virtual List<As> Assen { get; set; }

      public override string ToString()
      {
         return Tekst;
      }
   }
}
