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

      public FAQ GetFAQ(int id)
      {
         return repo.ReadFaq(id);
      }

      public void EditFaq(FAQ faq)
      {
         repo.UpdateFaq(faq);
      }

      public void RemoveFaq(int ID)
      {
         repo.DeleteFaq(ID);
      }

      public void AddContact(Contact contact)
      {
         repo.CreateContact(contact);
      }
   }
}
