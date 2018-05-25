using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Domain;
using DAL;

namespace BL
{
    public class AlertManager
    {
        private readonly AlertRepository repo;

        public AlertManager()
        {
            repo = new AlertRepository();
        }

        public Alert AddAlert(Alert alert)
        {
            return repo.CreateAlert(alert); ;
        }

        public Alert GetAlert(int ID)
        {
            return repo.ReadAlert(ID);
        }

        public IEnumerable<Alert> GetAlerts()
        {
            return repo.ReadAlerts();
        }

        public void RemoveAlert(int ID)
        {
            repo.DeleteAlert(ID);
        }
        public Gebruiker GetGebruiker(int ID)
        {
            return repo.GetGebruiker(ID);
        }
        public Grafiek GetGrafiek(int ID)
        {
            return repo.GetGrafiek(ID);
        }
    }
}
