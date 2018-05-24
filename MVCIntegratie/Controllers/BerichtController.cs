using BL;
using BL.Domain;
using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class BerichtController : Controller
   {
      private BerichtManager mng = new BerichtManager();

      public virtual ActionResult Index(string persoon = "")
      {
         IEnumerable<Bericht> berichten;
         if (persoon.Equals(""))
         {
            berichten = mng.GetBerichten();
         }
         else
         {
            berichten = mng.GetBerichten().Where(b => b.Personen.Contains(new Persoon() { Naam = persoon }));
         }

         return View(berichten);
      }

      public virtual ActionResult Details(string id)
      {
         Bericht bericht = mng.GetBericht(id);

         if (bericht == null)
         {
            return Index();
         }

         return View(bericht);
      }
   }
}