using BL.Domain.GrafiekKlassen;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekTypes
{
   public class Pie : Grafiek
   {
      public Pie() { }
      
      public Pie(int ID,
         string Titel,
         Serie serie)
      {
         this.ID = ID;
         this.Titel = Titel;
         Series = new List<Serie>();
         if (serie.Data.Count != 0)
         {
            serie.Data[0].Selected = true;
            serie.Data[0].Sliced = true;
         }
         serie.ColorByPoint = true;
         Series.Add(serie);

         Chart = new Chart()
         {
            PlotShadow = false,
            Type = "pie"
         };
         Tooltip = "{series.name}: <b>{point.percentage:.1f}%</b>";
         PlotOptions = new PlotOptions()
         {
            AllowPointSelect = true,
            Cursor = "pointer",
            DataLabels = false,
            ShowInLegend = true
         };
      }

   }
}
