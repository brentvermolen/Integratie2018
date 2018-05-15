using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.BerichtKlassen
{
   public class Mention : IComparable
   {
      [Key]
      public int ID { get; set; }
      public string Tekst { get; set; }

      public virtual ICollection<Bericht> Berichten { get; set; }

       public int CompareTo(Object obj)
       {
           
                if (obj == null) { return 1; }
                Mention mention = obj as Mention;

                if (mention != null)
                {
                    return this.Berichten.Count().CompareTo(mention.Berichten.Count());
                }
                else throw new ArgumentException("Dit is geen vermelding");
            
        }

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

         Mention o = (Mention)obj;

         if (o.Tekst.Equals(Tekst))
         {
            return true;
         }
         else return false;
      }
   }
}
