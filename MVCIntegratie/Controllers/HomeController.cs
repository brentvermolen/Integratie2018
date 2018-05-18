using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.ItemKlassen;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using System.Web;

namespace MVCIntegratie.Controllers
{
   [RequireHttps]
   public partial class HomeController : Controller
   {
      private BerichtManager berichtMng = new BerichtManager();
      private AlertManager alertMng = new AlertManager();
      private GebruikerManager gebruikerMng = new GebruikerManager();
      private GrafiekenManager grafiekenMng = new GrafiekenManager();

      public virtual ActionResult Index(string language)
      {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            if (User.Identity.IsAuthenticated)
         {
            List<Grafiek> graf = grafiekenMng.GetGrafieken().Where(g => g.GebruikerId == int.Parse(User.Identity.GetUserId())).ToList();
            graf.Sort((g, g2) => g.Order.CompareTo(g2.Order));

               
                return View("Home_Ingelogd", graf);
         }
         else
         {
            if (User.Identity.IsAuthenticated)
            {
               int id = int.Parse(User.Identity.GetUserId());
               List<Grafiek> graf = grafiekenMng.GetGrafieken().Where(g => g.Gebruiker.ID == id).ToList();

                    return View("Home_Ingelogd", graf);
            }
            else
            {
               List<Grafiek> graf = grafiekenMng.GetGrafieken().Where(g => g.isDefault == true).ToList();

                    return View(graf);
            }
         }
    
          

        }

        public class AantalTweetsPerWeek
        {
            public int Count { get; set; }
            public DateTime Week { get; set; }
        }

        public virtual ActionResult Zoek(string search, string language)

        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            return View();


        }

        public virtual ActionResult Search(string search, string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


            return RedirectToAction("Index", "Search");
        }


        public virtual ActionResult Toevoegen(string type, string language)
        {
            Grafiek graf = new Bar(0, "PREVIEW", new As() { IsUsed = true, Categorieen = new List<Categorie>() }, new List<Serie>());
            graf.xAs.Categorieen.Add(new Categorie("Objectiviteit"));
            graf.xAs.Categorieen.Add(new Categorie("Polariteit"));

            List<Persoon> personen = berichtMng.GetPersonen().ToList();
            personen.Sort((p1, p2) => p1.Naam.CompareTo(p2.Naam));

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


            return View("GrafiekToevoegen", new GrafiekPersonen() { Grafiek = graf, Personen = personen });
        }
       
    }

}