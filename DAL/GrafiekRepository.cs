using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class GrafiekRepository
   {
      private Integratie2018Context ctx;

      public GrafiekRepository()
      {
         ctx = new Integratie2018Context();
      }

      public IEnumerable<Grafiek> ReadGrafieken()
      {
         return ctx.Grafieken.Include("Series");
      }
   }
}
