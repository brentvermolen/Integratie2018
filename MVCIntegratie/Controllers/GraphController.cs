using BL;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCIntegratie.Controllers
{
   public partial class GraphController : Controller
   {
      private IBerichtManager berichtMng = new BerichtManager();
      private IAlertManager alertMng = new AlertManager();
      private IGebruikerManager gebruikerMng = new GebruikerManager();
      private GrafiekenManager grafiekenMng = new GrafiekenManager();

      // GET: Graph
      public virtual ActionResult Index()
      {
         var gebruiker = Membership.GetUser();

         List<Persoon> personen = berichtMng.GetPersonen().ToList();
         personen.Sort((p1, p2) => p1.Naam.CompareTo(p2.Naam));
         
         As xAsBar = new As() { IsUsed = true };

         NieuweGrafiekModel types = new NieuweGrafiekModel()
         {
            Bar = new Bar(0, "PREVIEW STAAF", xAsBar, new List<Serie>()),
            Line = new Lijn(1, "PREVIEW LIJN", new As(), new List<Serie>()),
            Pie = new Pie(2, "PREVIEW TAART", new Serie()),
            Personen = personen
         };

         return View(types);
      }
   }
}