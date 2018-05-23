using BL;
using BL.Domain;
using BL.Domain.GrafiekTypes;
using MVCIntegratie.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class PersoonController : Controller
   {
      private BerichtManager mng = new BerichtManager();
      private GrafiekenManager GrafiekenMng = new GrafiekenManager();

      public virtual ActionResult Index(int id)
      {
         Persoon persoon = mng.GetPersoon(id);
         Grafiek grafiek = new Lijn();

         grafiek.Titel = "Aantal Tweets - Per Dag - " + persoon.Naam;
         grafiek.ContentType = "politieker";
         grafiek.TitelXAs = "dag";
         grafiek.AantalSeries = 4;
         grafiek.Personen = new List<Persoon>();
         grafiek.Personen.Add(persoon);
         grafiek.TitelYAs = "Aantal Tweets";

         grafiek = GrafiekenMng.CreateGrafiek(grafiek);

         PersoonModel model = new PersoonModel()
         {
            Persoon = persoon,
            Grafiek = grafiek
         };
         return View(model);
      }
   }
}