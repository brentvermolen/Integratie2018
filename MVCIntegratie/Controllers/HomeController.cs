﻿using BL;
using BL.Domain;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using Microsoft.AspNet.Identity;
using MVCIntegratie.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class HomeController : Controller
   {
      private BerichtManager berichtMng = new BerichtManager();
      private AlertManager alertMng = new AlertManager();
      private GebruikerManager gebruikerMng = new GebruikerManager();
      private GrafiekenManager grafiekenMng = new GrafiekenManager();
      private DeelplatformManager platformMng = new DeelplatformManager();


      public virtual ActionResult Index(string language, string deelplatform)
      {
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
         Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

         Deelplatform platform = platformMng.GetDeelplatform(deelplatform);

         if (User.Identity.IsAuthenticated)
         {
            int id = int.Parse(User.Identity.GetUserId());
            List<Grafiek> graf = grafiekenMng.GetGrafieken().Where(g => g.Gebruiker.ID == id && g.Deelplatform.ID == platform.ID).ToList();
            graf.Sort((g1, g2) => g1.Order.CompareTo(g2.Order));

            HomeIngelogdModel model = new HomeIngelogdModel()
            {
               Grafieken = graf,
               Gebruiker = gebruikerMng.GetGebruiker(id)
            };

            return View("Home_Ingelogd", model);
         }
         else
         {
            List<Grafiek> graf = grafiekenMng.GetGrafieken().Where(g => g.isDefault == true && g.Deelplatform.ID == platform.ID).ToList();

            Random rand = new Random();
            int max = berichtMng.GetPersonen().ToList().Count;
            List<Persoon> pers = new List<Persoon>();
            
            if (max > 0)
            {
               for (int i = 0; i < 4; i++)
               {
                  pers.Add(berichtMng.GetPersoon(rand.Next(max)));
               }
            }

            HomeModel model = new HomeModel()
            {
               Grafieken = graf,
               Personen = pers
            };

            return View(model);
         }
      }

      public class AantalTweetsPerWeek
      {
         public int Count { get; set; }
         public DateTime Week { get; set; }
      }

    

      public virtual ActionResult Search(string search,string language, string deelplatform)
      {
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
         Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            Deelplatform platform = platformMng.GetDeelplatform(deelplatform);


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