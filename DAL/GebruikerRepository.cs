using BL.Domain;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class GebruikerRepository : IGebruikerRepository
   {
      private Integratie2018Context ctx;

      public GebruikerRepository()
      {
         ctx = new Integratie2018Context();
      }

      public Gebruiker CreateGebruiker(Gebruiker gebruiker)
      {
         ctx.Gebruikers.Add(gebruiker);
         ctx.SaveChanges();
         return gebruiker;
      }

      public void DeleteGebruiker(int id)
      {
         ctx.Gebruikers.Remove(ReadGebruiker(id));
         ctx.SaveChanges();
      }

      public Gebruiker ReadGebruiker(int id)
      {
         return ctx.Gebruikers.Find(id);
      }

      public IEnumerable<Gebruiker> ReadGebruikers()
      {
         return ctx.Gebruikers;
      }

      public void UpdateGebruiker(Gebruiker gebruiker)
      {
         ctx.Entry(gebruiker).State = System.Data.Entity.EntityState.Modified;
         ctx.SaveChanges();
      }
   }
}
