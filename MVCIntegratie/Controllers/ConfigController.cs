using BL;
using BL.Domain;
using Microsoft.AspNet.Identity;
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
      private GebruikerManager GebruikerMng = new GebruikerManager();

      public virtual ActionResult Gebruikers()
      {
         return View();
      }
      public virtual ActionResult Deelplatform()
      {
         return View();
      }

      private DeelplatformManager PlatformMng = new DeelplatformManager();

      public virtual ActionResult Admin(string deelplatform)
      {
         Gebruiker gr = GebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));
         Deelplatform platform = PlatformMng.GetDeelplatform(deelplatform);

         ViewBag.SuperAdmin = false;
         /*if (gr.isAdmin == false)
         {
           return Redirect("/home/index");
         }
         else
         {*/
         var gebruikers = GebruikerMng.GetGebruikers().ToList();
         gebruikers = gebruikers.Where(g => g.Deelplatformen.FirstOrDefault(p => p.ID == platform.ID) != null).ToList();

         AdminModel model = new AdminModel()
         {
            FAQ = FyiMng.GetFAQs().Where(f => f.DeelplatformID == platform.ID).OrderByDescending(f => f.GesteldOp).ToList(),
            Gebruikers = gebruikers
         };
         return View(model);
         /*}*/

      }

      public virtual ActionResult SuperAdmin(string deelplatform)
      {
         if (!User.Identity.IsAuthenticated)
         {
            return Redirect("/home/index");
         }
         else if (User.Identity.IsAuthenticated)
         {
            Gebruiker gebruiker = GebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));
            Deelplatform platform = PlatformMng.GetDeelplatform(deelplatform);
            ViewBag.SuperAdmin = true;

            if (gebruiker.isSuperAdmin)
            {
               AdminModel model = new AdminModel()
               {
                  FAQ = FyiMng.GetFAQs(true).OrderByDescending(f => f.GesteldOp).ToList(),
                  Gebruikers = GebruikerMng.GetGebruikers().Where(g => g.isSuperAdmin == false).OrderBy(g => g.Email).ToList(),
                  Deelplatformen = PlatformMng.GetDeelplatforms()
               };
               return View(model);
            }
            else
            {
               return Redirect("/home/index");
            }
         }
         return Redirect("/home/index");
      }
   }
}