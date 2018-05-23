using BL.Domain;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class DeelplatformManager
   {
      private DeelplatformRepository repo = new DeelplatformRepository();

      public List<Deelplatform> GetDeelplatforms()
      {
         return repo.ReadDeelplatforms();
      }

      public Deelplatform GetDeelplatform(string deelplatform)
      {
         return repo.ReadDeelplatform(deelplatform);
      }

      public Gebruiker GetGebruiker(int id)
      {
         return repo.ReadGebruiker(id);
      }

      public void ChangeObject(object platform)
      {
         repo.UpdateDeelplatform(platform);
      }

      public Deelplatform GetDeelplatform(int id)
      {
         return repo.ReadDeelplatform(id);
      }

      public Persoon GetPersoon(string naam)
      {
         return repo.GetPersoon(naam);
      }
   }
}
