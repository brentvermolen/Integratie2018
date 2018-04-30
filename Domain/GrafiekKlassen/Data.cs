using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekKlassen
{
   public class Data
   {
      public static int Count = 0;

      public Data() { Naam = "Data" + Count++; Series = new List<Serie>(); }
      public Data(double value)
      {
         Naam = "Data" + Count++;
         Value = value;
         Series = new List<Serie>();
      }

      [Key]
      public int ID { get; set; }
      public string Naam { get; set; }
      public double Value { get; set; }
      public bool Sliced { get; set; }
      public bool Selected { get; set; }

      public ICollection<Serie> Series { get; set; }
   }
}
