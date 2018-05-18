using BL;
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

      // GET: Deelplatform
      public virtual ActionResult Index()
      {
         return View(DeelplatformMng.GetDeelplatforms());
      }
   }
}