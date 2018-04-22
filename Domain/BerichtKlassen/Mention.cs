﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.BerichtKlassen
{
   public class Mention
   {
      [Key]
      public int ID { get; set; }
      public string Tekst { get; set; }

      public ICollection<Bericht> Berichten { get; set; }

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

         return false;
      }
   }
}
