using BL.Domain.GrafiekKlassen;
//using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekTypes
{
   public class Bar : Grafiek
   {
      public Bar() { }

      public Bar(int ID,
         string Titel,
         As xAsCategorieën,
         List<Serie> Series)
      {
         this.ID = ID;
         this.Titel = Titel;
         Chart = new Chart()
         {
            Type = "column"
         };
         Credits = false;
         xAs = xAsCategorieën;
         this.Series = Series;
      }
   }
}
