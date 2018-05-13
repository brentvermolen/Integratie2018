using BL;
using BL.Domain;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.ItemKlassen;
using Microsoft.AspNet.Identity;
using MVCIntegratie.Models;
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
         if (User.Identity.IsAuthenticated == false)
         {
            return Redirect("/Home/Index");
         }

         As xAsBar = new As() { IsUsed = true };

         NieuweGrafiekModel types = new NieuweGrafiekModel()
         {
            Bar = new Bar(0, "PREVIEW STAAF", xAsBar, new List<Serie>()),
            Line = new Lijn(1, "PREVIEW LIJN", new As(), new List<Serie>()),
            Pie = new Pie(2, "PREVIEW TAART", new Serie())
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
            Bar = new Bar(0, "PREVIEW STAAF", xAsBar, new List<Serie>()),
            Line = new Lijn(1, "PREVIEW LIJN", new As(), new List<Serie>()),
            Pie = new Pie(2, "PREVIEW TAART", new Serie()),
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