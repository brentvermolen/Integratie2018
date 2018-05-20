using BL;
using BL.Domain;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using Microsoft.AspNet.Identity;
using MVCIntegratie.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class GraphController : Controller
   {
      private BerichtManager berichtMng = new BerichtManager();
      private AlertManager alertMng = new AlertManager();
      private GebruikerManager gebruikerMng = new GebruikerManager();
      private GrafiekenManager grafiekenMng = new GrafiekenManager();

      // GET: Graph
      public virtual ActionResult Index()
      {
         if (User.Identity.IsAuthenticated == false)
         {
            return Redirect("/Home/Index");
         }

         As xAsBar = new As() { IsUsed = true };

         NieuweGrafiekModel types = new NieuweGrafiekModel()
         {
            Bar = new Bar(-1, "PREVIEW STAAF", xAsBar, new List<Serie>()),
            Line = new Lijn(-2, "PREVIEW LIJN", new As(), new List<Serie>()),
            Pie = new Pie(-3, "PREVIEW TAART", new Serie())
         };

         return View(types);
      }

      public virtual ActionResult Wijzig(int id)
      {
         int userID = int.Parse(User.Identity.GetUserId());
         Grafiek gr = grafiekenMng.GetGrafieken().FirstOrDefault(g => g.ID == id);
         
         if (gr.Gebruiker.ID != userID)
         {
            Redirect("/Home/Index");
         }

         As xAsBar = new As() { IsUsed = true };
         NieuweGrafiekModel model = new NieuweGrafiekModel()
         {
            Bar = new Bar(-1, "PREVIEW STAAF", xAsBar, new List<Serie>()),
            Line = new Lijn(-2, "PREVIEW LIJN", new As(), new List<Serie>()),
            Pie = new Pie(-3, "PREVIEW TAART", new Serie()),
            IsGewijzigd = true
         };

         switch (gr.Chart.Type)
         {
            case "normal":
               model.Line = gr;
               model.GewijzigdType = "lijn";
               break;
            case "pie":
               model.Pie = gr;
               model.GewijzigdType = "taart";
               break;
            case "column":
               model.Bar = gr;
               model.GewijzigdType = "staaf";
               break;

         }

         return View("Index", model);
      }
   }
}