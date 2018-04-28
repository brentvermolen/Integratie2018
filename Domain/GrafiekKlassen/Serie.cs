using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekKlassen
{
   public class Serie
   {
      public static int Count = 0;

      public Serie()
      {
         Naam = "Serie" + Count++;
         Data = new List<Data>();
         Grafieken = new List<Grafiek>();
      }

      [Key]
      public string Naam { get; set; }
      public virtual List<Data> Data { get; set; }
      public bool ColorByPoint { get; set; }

      public ICollection<Grafiek> Grafieken { get; set; } 


      public string GetDataString()
      {
         string ret = "[";

         for(int i = 0; i < Data.Count; i++)
         {
            Data data = Data[i];
            if (data.Value == 0)
            {
               ret += "null";
            }
            else
            {
               ret += data.Value.ToString();
            }

            if (i != Data.Count - 1)
            {
               ret += ", ";
            }
         }

         return ret + "]";
      }
   }
}
