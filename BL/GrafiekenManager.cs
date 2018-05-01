using BL.Domain;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class GrafiekenManager
   {
      private readonly GrafiekRepository repo;

      public GrafiekenManager()
      {
         repo = new GrafiekRepository();
      }

      public IEnumerable<Grafiek> GetGrafieken()
      {
         return repo.ReadGrafieken();
      }

      public Grafiek NewGrafiek()
      {
         return repo.CreateGrafiek();
      }

      public void AddGrafiek(Grafiek grafiek)
      {
         repo.SaveGrafiek(grafiek);
      }

      public void RemoveGrafiek(int ID)
      {
         repo.DeleteGrafiek(ID);
      }
   }
}
