using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public class HomeController : Controller
   {
      private IBerichtManager mng = new BerichtManager();

      public ActionResult Index()
      {
         List<Persoon> personen = mng.GetPersonen().ToList();
         List<Woord> woorden = mng.GetWoorden().ToList();

         return View();
      }

      public ActionResult About()
      {
         ViewBag.Message = "Your application description page.";

         return View();
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "Your contact page.";

         return View();
      }
   }
}