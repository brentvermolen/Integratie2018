using BL.Domain;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class FYIManager
   {
      private FYIRepository repo;

      public FYIManager()
      {
         repo = new FYIRepository();
      }

      public IEnumerable<FAQ> GetFAQs()
      {
         return repo.ReadFaqs();
      }

      public void AddFaq(FAQ faq)
      {
         repo.CreateFaq(faq);
      }
   }
}
