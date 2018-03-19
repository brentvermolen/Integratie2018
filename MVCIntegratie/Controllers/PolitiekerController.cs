using BL;
using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class PolitiekerController : Controller
   {
      private IBerichtManager mng = new BerichtManager();

      public virtual ActionResult Details(string naam)
      {
         Persoon persoon = mng.GetPersoon(naam);

         return View(persoon);
      }
   }
}