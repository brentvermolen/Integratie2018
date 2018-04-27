using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
    public partial class FYIController : Controller
    {
        // GET: FYI
        public virtual ActionResult Over()
        {
            return View();
        }

        public virtual ActionResult FAQ()
        {
            return View();
        }

        public virtual ActionResult Contact()
        {
            return View();
        }
    }
}