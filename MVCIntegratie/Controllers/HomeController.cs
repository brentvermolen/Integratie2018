using BL;
using BL.Domain;
using BL.Domain.AlertKlassen;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using BL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace MVCIntegratie.Controllers
{
    [RequireHttps]

    public partial class HomeController : Controller

   {
      private IBerichtManager berichtMng = new BerichtManager();
      private IAlertManager alertMng = new AlertManager();
      private IGebruikerManager gebruikerMng = new GebruikerManager();

      public virtual ActionResult Index()
      {
         List<Bericht> test = berichtMng.GetBerichten().ToList();
         
         //string json = JsonExport.Lijst(test);

         return View(new List<AlertResultaat>());
      }

      /*private List<AlertResultaat> AlertPolitieker(List<Bericht> oudeData, List<Bericht> nieuweData)
      {
         List<PolitiekVergelijker> oud = new List<PolitiekVergelijker>();
         List<PolitiekVergelijker> nieuw = new List<PolitiekVergelijker>();

         foreach (Bericht berichtOud in oudeData)
         {
            PolitiekVergelijker pol = new PolitiekVergelijker() { Politieker = berichtOud.Politieker.Naam, Aantal = 1 };
            if (!oud.Contains(pol))
            {
               oud.Add(pol);
            }
            else
            {
               oud.Find((p) => p.Politieker.Equals(berichtOud.Politieker.Naam)).Aantal++;
            }
         }

         foreach (Bericht berichtNieuw in nieuweData)
         {
            PolitiekVergelijker pol = new PolitiekVergelijker() { Politieker = string.Join(" ", berichtNieuw.Politieker), Aantal = 1 };
            if (!nieuw.Contains(pol))
            {
               nieuw.Add(pol);
            }
            else
            {
               nieuw.Find((p) => p.Politieker.Equals(string.Join(" ", berichtNieuw.Politieker))).Aantal++;
            }
         }

         List<Gebruiker> gebruikers = gebruikerMng.GetGebruikers().ToList();
         List<AlertResultaat> teTonen = new List<AlertResultaat>();

         foreach (PolitiekVergelijker politiekVergelijker in nieuw)
         {
            if (oud.Contains(politiekVergelijker))
            {
               int oudAantal = oud.Find((p) => p.Politieker.Equals(politiekVergelijker.Politieker)).Aantal;
               int nieuwAantal = nieuw.Find((p) => p.Politieker.Equals(politiekVergelijker.Politieker)).Aantal;
               
               var group = nieuweData.Where(b => b.Politieker.Naam.Equals(politiekVergelijker.Politieker)).GroupBy(b => new DateTime(b.Datum.Year, b.Datum.Month, b.Datum.Day)).ToList();
               List<int> aantalPerDag = new List<int>();
               foreach (var item in group)
               {
                  aantalPerDag.Add(item.Count());
               }
               int gemiddeldeperDag = (int)aantalPerDag.Average();

               double afwijking = BerekenAfwijking(aantalPerDag);

               int percentage = (nieuwAantal - gemiddeldeperDag) / gemiddeldeperDag * 100;

               int verschil = oudAantal - nieuwAantal;
               foreach (Gebruiker gebruiker in gebruikers)
               {
                  List<Alert> alerts = alertMng.GetAlerts().Where(a => a.Gebruiker.ID == gebruiker.ID).ToList();
                  foreach (Alert alert in alerts)
                  {
                     double Zscore = (nieuwAantal - gemiddeldeperDag) / afwijking;

                     if (alert.Type.Equals("Aantal"))
                     {
                        if (Zscore > 1)
                        {
                           teTonen.Add(new AlertResultaat()
                           {
                              Alert = alert,
                              Gebruiker = gebruiker,
                              Resultaat = "Trending"
                           });
                        }
                        else
                        {
                           if (Zscore < -1)
                           {
                              teTonen.Add(new AlertResultaat()
                              {
                                 Alert = alert,
                                 Gebruiker = gebruiker,
                                 Resultaat = "Niet meer populair"
                              });
                           }
                        }
                     }

                     if (alert.Type.Equals("Politieker"))
                     {
                        if (percentage >= alert.Percentage)
                        {
                           teTonen.Add(new AlertResultaat()
                           {
                              Alert = alert,
                              Gebruiker = gebruiker,
                              Resultaat = percentage.ToString() + "% gestegen"
                           });
                        }
                     }
                  }
               }
            }
         }

         return teTonen;
      }*/

      public double BerekenAfwijking(List<int> totalen)
      {
         //Compute the Average      
         double avg = totalen.Average();
         //Perform the Sum of (value-avg)_2_2      
         double sum = totalen.Sum(d => Math.Pow(d - avg, 2));
         //Put it all together      
         return Math.Sqrt((sum) / (totalen.Count() - 1));
      }

      public class PolitiekVergelijker
      {
         public string Politieker { get; set; }
         public int Aantal { get; set; }

         public override bool Equals(object obj)
         {
            if (obj.GetType() != GetType())
            {
               return false;
            }

            PolitiekVergelijker politiekVergelijker = (PolitiekVergelijker)obj;
            if (politiekVergelijker.Politieker.Equals(Politieker))
            {
               return true;
            }

            return false;
         }

         public override string ToString()
         {
            return Politieker;
         }
      }
   }
}