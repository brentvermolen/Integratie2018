using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Domain;

namespace DAL
{
   public class AlertRepository : IAlertRepository
   {
      private Integratie2018Context ctx;

      public AlertRepository()
      {
         ctx = new Integratie2018Context();
         ctx.Database.Initialize(false);
      }

      public Alert CreateAlert(Alert alert)
      {
         ctx.Alerts.Add(alert);
         ctx.SaveChanges();
         return alert;
      }

      public void DeleteAlert(int ID)
      {
         ctx.Alerts.Remove(ReadAlert(ID));
         ctx.SaveChanges();
      }

      public Alert ReadAlert(int ID)
      {
         return ctx.Alerts
            .Include("Gebruiker")
            .FirstOrDefault(g => g.ID == ID);
      }

      public IEnumerable<Alert> ReadAlerts()
      {
         return ctx.Alerts
            .Include("Gebruiker");
      }

      public void UpdateAlert(Alert alert)
      {
         ctx.Entry(alert).State = System.Data.Entity.EntityState.Modified;
         ctx.SaveChanges();
      }
   }
}
