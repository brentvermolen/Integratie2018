using BL;
using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class FYIController : Controller
   {
      private FYIManager FyiMng = new FYIManager();

      // GET: FYI
      public virtual ActionResult Over()
      {
         return View();
      }

      public virtual ActionResult FAQ()
      {
         return View(FyiMng.GetFAQs().ToList());
      }

      public virtual ActionResult Contact()
      {
         return View();
      }
   }
}