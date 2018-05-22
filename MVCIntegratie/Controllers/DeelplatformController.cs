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
   public partial class DeelplatformController : Controller
   {
      private DeelplatformManager DeelplatformMng = new DeelplatformManager();
      private GebruikerManager GebruikerMng = new GebruikerManager();

      // GET: Deelplatform
      public virtual ActionResult Index()
      {
         ViewBag.Title = "Deelplatformen"; List<Deelplatform> Deelplatformen = DeelplatformMng.GetDeelplatforms();


         if (User.Identity.IsAuthenticated)
         {
            Gebruiker gebruiker = GebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));
            
            if (gebruiker.Deelplatformen.Count == 1)
            {
               return RedirectToAction("Index", "Home", new { deelplatform = gebruiker.Deelplatformen[0].Naam });
            }
            else
            {
               DeelplatformModel model = new DeelplatformModel()
               {
                  AndereDeelplatformen = Deelplatformen.Where(d => gebruiker.Deelplatformen.FirstOrDefault(g => g.ID == d.ID) == null).ToList(),
                  MijnDeelplatformen = Deelplatformen.Where(d => gebruiker.Deelplatformen.FirstOrDefault(g => g.ID != d.ID) == null).ToList()
               };

               return View(model);
            }
         }
         else
         {
            DeelplatformModel model = new DeelplatformModel()
            {
               AndereDeelplatformen = Deelplatformen,
               MijnDeelplatformen = new List<Deelplatform>()
            };

            return View(model);
         }
      }

      public virtual ActionResult Registreer()
      {
         ViewBag.Title = "Registreer Deelplatform";

         if (User.Identity.IsAuthenticated == false)
         {
            return RedirectToRoute("Default", new { action = "Index" });
         }

         Gebruiker gebruiker = GebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));
         List<Deelplatform> Deelplatformen = DeelplatformMng.GetDeelplatforms();

         DeelplatformModel model = new DeelplatformModel()
         {
            AndereDeelplatformen = Deelplatformen.Where(d => gebruiker.Deelplatformen.FirstOrDefault(g => g.ID == d.ID) == null).ToList(),
            MijnDeelplatformen = Deelplatformen.Where(d => gebruiker.Deelplatformen.FirstOrDefault(g => g.ID != d.ID) == null).ToList()
         };

         return View("Index", model);
      }
   }
}