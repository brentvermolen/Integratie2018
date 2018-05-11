using BL;
using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
   public class TestLogicaController : Controller
   {
      private FYIManager FyiMng = new FYIManager();

      // GET: LogicaTest
      public ActionResult Index()
      {
         List<FAQ> faqs = FyiMng.GetFAQs().ToList();
         faqs.Sort((f1, f2) => f2.GesteldOp.CompareTo(f1.GesteldOp));

         return View(faqs);
      }
   }
}