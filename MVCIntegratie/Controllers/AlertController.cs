using BL;
using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public partial class AlertController : Controller
   {
      private AlertManager mng = new AlertManager();

      public virtual ActionResult Index()
      {
         IEnumerable<Alert> alerts = mng.GetAlerts();

         return View(alerts);
      }

     public virtual ActionResult ManageAlerts()
     {
       return View();
     }
  }
}