using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
   public interface IGebruikerRepository
   {
      Gebruiker CreateGebruiker(Gebruiker gebruiker);
      IEnumerable<Gebruiker> ReadGebruikers();
      Gebruiker ReadGebruiker(int id);
      void UpdateGebruiker(Gebruiker gebruiker);
      void DeleteGebruiker(int id);
   }
}
