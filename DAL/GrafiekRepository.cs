﻿using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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
               .Include("Gebruiker")
               .Include("Deelplatform");
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

      public void UpdateGrafiek(Grafiek grafiek)
      {
         ctx.Entry(grafiek).State = System.Data.Entity.EntityState.Modified;
         ctx.SaveChanges();
      }

      public Deelplatform ReadDeelplatform(string deelplatform)
      {
         return ctx.Deelplatformen.Include("Gebruikers").Include("Admins").FirstOrDefault(d => d.Naam.Equals(deelplatform));
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
