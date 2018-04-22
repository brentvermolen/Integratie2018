using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.BerichtKlassen
{
   public class Hashtag
   {
      [Key]
      public int ID { get; set; }
      public string Tekst { get; set; }

      public List<Bericht> Berichten { get; set; }

      public override bool Equals(object obj)
      {
         if (obj.GetType() != GetType())
         {
            return false;
         }

         Hashtag hashtag = (Hashtag)obj;

         if (hashtag.Tekst.Equals(Tekst))
         {
            return true;
         }

         return false;
      }

      public override string ToString()
      {
         return Tekst;
      }
   }
}
