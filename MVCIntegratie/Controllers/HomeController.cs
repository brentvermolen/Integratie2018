using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         Integratie2018Context ctx = new Integratie2018Context();
         List<Bericht> berichten = ctx.Berichten.ToList();

         berichten.ToString();

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