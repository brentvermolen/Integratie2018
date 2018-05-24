using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{

    [HandleError]
    public partial class ErrorController : Controller
    {
        // GET: Error
        public virtual ActionResult Index()
        {
            throw new Exception("Error Occured !");
            return View("Index");
        }
        public virtual ViewResult NotFound()
        {
            Response.StatusCode = 404;

            return View("Index");
        }
    }
}
