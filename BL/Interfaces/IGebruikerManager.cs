using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IGebruikerManager
   {
      Gebruiker AddGebruiker(Gebruiker gebruiker);
      IEnumerable<Gebruiker> GetGebruikers();
      Gebruiker GetGebruiker(int id);
      void RemoveGebruiker(int id);
   }
}
