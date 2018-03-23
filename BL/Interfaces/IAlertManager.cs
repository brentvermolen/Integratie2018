using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IAlertManager
   {
      IEnumerable<Alert> GetAlerts();
      Alert GetAlert(int ID);
      Alert AddAlert(Alert alert);
      void RemoveAlert(int ID);
   }
}
