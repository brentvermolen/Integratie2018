using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
    public partial class GraphController : Controller
    {
        // GET: Graph
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}