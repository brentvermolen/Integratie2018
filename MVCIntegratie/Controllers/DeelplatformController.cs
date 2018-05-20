﻿using BL;
using BL.Domain;
using Microsoft.AspNet.Identity;
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
         if (User.Identity.IsAuthenticated)
         {
            Gebruiker gebruiker = GebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));

            if (gebruiker.Deelplatformen.Count == 1)
            {
               return RedirectToAction("Index", "Home", new { deelplatform = gebruiker.Deelplatformen[0].Naam });
            }
            else
            {
               return View(DeelplatformMng.GetDeelplatforms().Where(d => d.Gebruikers.Contains(gebruiker)).ToList());
            }
         }
         else
         {
            return View(DeelplatformMng.GetDeelplatforms());
         }
      }
   }
}