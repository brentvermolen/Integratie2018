using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface IAlertRepository
   {
      Alert CreateAlert(Alert alert);
      IEnumerable<Alert> ReadAlerts();
      Alert ReadAlert(int ID);
      void UpdateAlert(Alert alert);
      void DeleteAlert(int ID);
   }
}
