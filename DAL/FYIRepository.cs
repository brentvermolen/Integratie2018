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
   }
}
