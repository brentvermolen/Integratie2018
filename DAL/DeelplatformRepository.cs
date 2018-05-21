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

      public Gebruiker ReadGebruiker(int id)
      {
         return ctx.Gebruikers.Find(id);
      }

      public void UpdateDeelplatform(object platform)
      {
         ctx.Entry(platform).State = System.Data.Entity.EntityState.Modified;
         ctx.SaveChanges();
      }

      public Deelplatform ReadDeelplatform(int id)
      {
         return ctx.Deelplatformen.Find(id);
      }
   }
}
