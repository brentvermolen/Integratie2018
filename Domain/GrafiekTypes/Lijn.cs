using BL.Domain.GrafiekKlassen;
//using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekTypes
{
   public class Lijn : Grafiek
   {
      public Lijn()
      {
         Chart = new Chart() { Type = "normal" };
         Legende = new Legende()
         {
            Layout = "vertical",
            Alignment = "right",
            VerticalAlign = "middle"
         };
         PlotOptions = new PlotOptions()
         {
            SeriesLabelConnector = false
         };
      }

      public Lijn(int ID,
         string Titel,
         As yAs,
         List<Serie> Series)
      {
         this.ID = ID;
         this.Titel = Titel;
         this.yAs = yAs;
         this.Series = Series;
         Chart = new Chart() { Type = "normal" };
         Legende = new Legende()
         {
            Layout = "vertical",
            Alignment = "right",
            VerticalAlign = "middle"
         };
         PlotOptions = new PlotOptions()
         {
            SeriesLabelConnector = false
         };
      }
   }
}
