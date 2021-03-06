﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.BerichtKlassen
{
   public class Woord
   {
      [Key]
      public int ID { get; set; }
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
            if (obj.GetType() == typeof(string))
            {
               string woord = (string)obj;
               if (woord.Equals(Tekst))
               {
                  return true;
               }
            }
            else
            {
               return false;
            }
         }

         Woord o = (Woord)obj;

         if (o.Tekst.Equals(Tekst))
         {
            return true;
         }

         return false;
      }
   }
}
