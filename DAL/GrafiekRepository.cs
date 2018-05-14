using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Domain;
using BL.Domain.ItemKlassen;

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
         return ctx.Grafieken
               .Include("Gebruiker");
      }

      public Grafiek CreateGrafiek()
      {
         try
         {
            return new Grafiek() { ID = ctx.Grafieken.Max(g => g.ID) + 1 };
         }
         catch
         {
            return new Grafiek() { ID = 0 };
         }

      }

      public Persoon ReadPersoon(int id)
      {
         return ctx.Personen
            .Include("Berichten")
            .FirstOrDefault(p => p.ID == id);
      }

      public void SaveGrafiek(Grafiek grafiek)
      {
         ctx.Grafieken.Add(grafiek);
         ctx.SaveChanges();
      }

      public void DeleteGrafiek(int ID)
      {
         try
         {
            Grafiek grafiek = ReadGrafieken().FirstOrDefault(g => g.ID == ID);
            ctx.Grafieken.Remove(grafiek);
            ctx.SaveChanges();
         }
         catch (Exception e) { }
      }

      /*public int GetSerieID()
      {
        return ctx.Series.Max(s => s.ID);
      }

      public int GetDataID()
      {
        return ctx.Datas.Max(d => d.ID);
      }*/
   }
}
