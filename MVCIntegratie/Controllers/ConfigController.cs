using BL;
using BL.Domain;
using Microsoft.AspNet.Identity;
using MVCIntegratie.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
      private BerichtManager BerichtMng = new BerichtManager();

      public virtual ActionResult Admin(string deelplatform)
      {
         Gebruiker gr = GebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));
         Deelplatform platform = PlatformMng.GetDeelplatform(deelplatform);

         ViewBag.SuperAdmin = false;
         if (gr.IsAdmin.FirstOrDefault(a => a.ID == platform.ID) != null)
         {
            return Redirect("/home/index");
         }
         else
         {
            var gebruikers = GebruikerMng.GetGebruikers().ToList();
            gebruikers = gebruikers.Where(g => g.Deelplatformen.FirstOrDefault(p => p.ID == platform.ID) != null && g.isSuperAdmin == false).ToList();

            AdminModel model = new AdminModel()
            {
               FAQ = FyiMng.GetFAQs().Where(f => f.DeelplatformID == platform.ID).OrderByDescending(f => f.GesteldOp).ToList(),
               Gebruikers = gebruikers,
               Personen = BerichtMng.GetPersonen(true).Where(p => p.DeelplatformID == platform.ID).OrderBy(p => p.Naam).ToList()
            };
            return View(model);
         }
      }

      [HttpPost]
      public virtual ActionResult PostUploadFile(string deelplatform, HttpPostedFileBase file)
      {
         using (StreamReader sr = new StreamReader(file.InputStream))
         {
            PersonenJson personen = JsonConvert.DeserializeObject<PersonenJson>("{ \"personen\": " + sr.ReadToEnd() + " }");

            int platformID = PlatformMng.GetDeelplatform(deelplatform).ID;
            foreach (Persoon p in personen.Personen)
            {
               Persoon persoonDb = PlatformMng.GetPersoon(p.Naam);
               if (persoonDb != null)
               {
                  if (persoonDb.Disabled == true)
                  {
                     persoonDb.District = p.District;
                     persoonDb.Facebook = p.Facebook;
                     persoonDb.Geboortedatum = p.Geboortedatum;
                     persoonDb.Geslacht = p.Geslacht;
                     persoonDb.Organisatie = p.Organisatie;
                     persoonDb.Postcode = p.Postcode;
                     persoonDb.Trending = p.Trending;
                     persoonDb.Twitter = p.Twitter;
                     persoonDb.Website = p.Website;
                     persoonDb.Disabled = false;
                     PlatformMng.ChangeObject(persoonDb);
                  }
               }
            }
         }

         return RedirectToAction("SuperAdmin");
      }

      public class PersonenJson
      {
         [JsonProperty("personen")]
         public List<Persoon> Personen { get; set; }
      }

      public virtual ActionResult SuperAdmin(string deelplatform)
      {
         if (!User.Identity.IsAuthenticated)
         {
            return Redirect("/Home/Index");
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
                  Deelplatformen = PlatformMng.GetDeelplatforms(),
                  Personen = BerichtMng.GetPersonen(true).OrderBy(p => p.Naam).ToList()
               };
               return View(model);
            }
            else
            {
               return Redirect("/Config/Admin");
            }
         }
         return Redirect("/Home/Index");
      }
   }
}