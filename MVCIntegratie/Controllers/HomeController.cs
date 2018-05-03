using BL;
using BL.Domain;
using BL.Domain.AlertKlassen;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using BL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace MVCIntegratie.Controllers
{
    [RequireHttps]
    public partial class HomeController : Controller

   {


      private IBerichtManager berichtMng = new BerichtManager();
      private IAlertManager alertMng = new AlertManager();
      private IGebruikerManager gebruikerMng = new GebruikerManager();

        public virtual ActionResult Home_Ingelogd()
        {
            return View();
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Search(string search)
        {
         

            return RedirectToAction("Index","Search") ;
        }

      
    }
}