using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.BerichtKlassen
{
   public class Url : IComparable
   {
      [Key]
      public int ID { get; set; }
      [MaxLength(500)]
      public string Tekst { get; set; }

      public virtual ICollection<Bericht> Berichten { get; set; }

      public override string ToString()
      {
         return Tekst;
      }

      public override bool Equals(object obj)
      {
         if (obj.GetType() != GetType())
         {
            return false;
         }

         Url o = (Url)obj;

         if (o.Tekst.Equals(Tekst))
         {
            return true;
         }

         return false;
      }

        public int CompareTo(object obj)
        {
            
                if (obj == null) { return 1; }
                Url url = obj as Url;

                if (url != null)
                {
                    return this.Berichten.Count().CompareTo(url.Berichten.Count());
                }
                else throw new ArgumentException("Dit is geen url");
            
        }
    }
}
