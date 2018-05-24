using BL.Domain;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class SyncManager
   {
      private readonly SyncRepository repo = new SyncRepository();

      public Synchronize GetSync()
      {
         return repo.ReadSync();
      }

      public void ChangeSync(Synchronize sync)
      {
         repo.UpdateSync(sync);
      }
   }
}
