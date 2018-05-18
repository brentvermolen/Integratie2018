using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class SyncRepository
   {
      private readonly Integratie2018Context ctx = new Integratie2018Context();

      public Synchronize ReadSync()
      {
         var syncs = ctx.Synchronizes.ToList();
         if (syncs.Count == 0)
         {
            Synchronize sync = new Synchronize();
            sync.LaatsteSync = new DateTime(2018, 3, 1);
            CreateSync(sync);
            return sync;
         }
         else if (syncs.Count > 1)
         {
            return syncs.OrderByDescending(s => s.LaatsteSync).ToList()[0];
         }
         else
         {
            return syncs[0];
         }
      }

      public void UpdateSync(Synchronize sync)
      {
         ctx.Entry(sync).State = System.Data.Entity.EntityState.Modified;
         ctx.SaveChanges();
      }

      public void CreateSync(Synchronize sync)
      {
         ctx.Synchronizes.Add(sync);
         ctx.SaveChanges();
      }
   }
}
