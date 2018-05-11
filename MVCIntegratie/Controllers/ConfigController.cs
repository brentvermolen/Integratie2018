using BL;
using BL.Domain;
using MVCIntegratie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class ConfigController : Controller
   {
      private FYIManager FyiMng = new FYIManager();
      private IGebruikerManager GebruikerMng = new GebruikerManager();

      // GET: Config
      public virtual ActionResult AdminConfig()
      {
         return View();
      }
      public virtual ActionResult Gebruikers()
      {
         return View();
      }
      public virtual ActionResult Deelplatform()
      {
         return View();
      }
      public virtual ActionResult Admin()
      {
         AdminModel model = new AdminModel()
         {
            FAQ = FyiMng.GetFAQs().OrderByDescending(f => f.GesteldOp).ToList(),
            Gebruikers = GebruikerMng.GetGebruikers().OrderBy(g => g.Naam).ToList()
         };
         return View(model);
      }
   }
}