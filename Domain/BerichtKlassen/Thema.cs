using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.BerichtKlassen
{
   public class Thema
   {
      [Key]
      public string Tekst { get; set; }

      public List<Bericht> Berichten { get; set; }

      public override string ToString()
      {
         return Tekst;
      }
   }
}
