using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
    public partial class ConfigController : Controller
    {
        // GET: Config
        public virtual ActionResult AdminConfig()
        {
            return View();
        }
        public virtual ActionResult Gebruikers()
        {
            return View();
        }
        public virtual ActionResult Deelplatform()
        {
            return View();
        }
    }
}