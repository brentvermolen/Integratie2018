using BL;
using BL.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class FYIController : Controller
   {
      private FYIManager FyiMng = new FYIManager();
      private DeelplatformManager platformMng = new DeelplatformManager();

      // GET: FYI
      public virtual ActionResult Over(string language)
      {
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
         Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

         return View();
      }

      public virtual ActionResult FAQ(string language, string deelplatform)
      {
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
         Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

         Deelplatform platform = platformMng.GetDeelplatform(deelplatform);

         return View(FyiMng.GetFAQs().Where(f => f.DeelplatformID == platform.ID).ToList());
      }

      public virtual ActionResult Contact(string language)
      {
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
         Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

         return View();
      }
   }
}