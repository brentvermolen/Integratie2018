using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class FYIRepository
   {
      private readonly Integratie2018Context ctx;

      public FYIRepository()
      {
         ctx = new Integratie2018Context();
      }

      public IEnumerable<FAQ> ReadFaqs()
      {
         return ctx.FAQ;
      }

      public void CreateFaq(FAQ faq)
      {
         ctx.FAQ.Add(faq);
         ctx.SaveChanges();
      }

      public FAQ ReadFaq(int id)
      {
         return ctx.FAQ.Find(id);
      }

      public void UpdateFaq(FAQ faq)
      {
         if (ReadFaq(faq.ID) == null)
         {
            return;
         }

         ctx.Entry(faq).State = System.Data.Entity.EntityState.Modified;
         ctx.SaveChanges();
      }

      public void CreateContact(Contact contact)
      {
         ctx.Contacts.Add(contact);
         ctx.SaveChanges();
      }

      public void DeleteFaq(int ID)
      {
         FAQ f = ReadFaq(ID);
         if (f == null)
         {
            return;
         }

         ctx.FAQ.Remove(f);
         ctx.SaveChanges();
      }
   }
}
