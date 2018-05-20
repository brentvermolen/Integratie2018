using BL;
using BL.Domain;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class PersoonController : Controller
   {
      private BerichtManager mng = new BerichtManager();

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