using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekKlassen
{
   public class PlotOptions
   {
      public bool SeriesLabelConnector { get; set; }
      public string PointStart { get; set; }
      public string PointInterval { get; set; }
      public bool AllowPointSelect { get; set; }
      public string Cursor { get; set; }
      public bool DataLabels { get; set; }
      public bool ShowInLegend { get; set; }

      public string getBool(bool boolean)
      {
         if (boolean)
         {
            return "true";
         }
         return "false";
      }
   }
}
