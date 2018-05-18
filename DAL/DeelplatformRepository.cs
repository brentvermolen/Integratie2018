using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DeelplatformRepository
   {
      private readonly Integratie2018Context ctx = new Integratie2018Context();

      public List<Deelplatform> ReadDeelplatforms()
      {
         return ctx.Deelplatformen.ToList();
      }

      public Deelplatform ReadDeelplatform(string deelplatform)
      {
         return ctx.Deelplatformen.FirstOrDefault(d => d.Naam.Equals(deelplatform));
      }
   }
}
