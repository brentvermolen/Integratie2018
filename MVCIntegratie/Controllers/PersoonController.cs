using BL;
using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class PersoonController : Controller
   {
      private IBerichtManager mng = new BerichtManager();

      public virtual ActionResult Index()
      {
         IEnumerable<Persoon> personen = mng.GetPersonen();

         return View(personen);
      }

      public virtual ActionResult Details(int id)
      {
         Persoon persoon = mng.GetPersoon(id);

         return View(persoon);
      }
   }
}