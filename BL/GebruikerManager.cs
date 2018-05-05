using BL.Domain;
using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class GebruikerManager : IGebruikerManager
   {
      private IGebruikerRepository repo;

      public GebruikerManager()
      {
         repo = new GebruikerRepository();
      }

      public Gebruiker AddGebruiker(Gebruiker gebruiker)
      {
         return repo.CreateGebruiker(gebruiker);
      }

      public Gebruiker GetGebruiker(int id)
      {
         return repo.ReadGebruiker(id);
      }

      public IEnumerable<Gebruiker> GetGebruikers()
      {
         return repo.ReadGebruikers();
      }

      public void RemoveGebruiker(int id)
      {
         repo.DeleteGebruiker(id);
      }
   }
}
