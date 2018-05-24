using BL;
using BL.Domain;
using Microsoft.AspNet.Identity;
using MVCIntegratie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
  public partial class ConfigController : Controller
  {
    private FYIManager FyiMng = new FYIManager();
    private GebruikerManager GebruikerMng = new GebruikerManager();

    public virtual ActionResult Gebruikers()
    {
      return View();
    }
    public virtual ActionResult Deelplatform()
    {
      return View();
    }
    public virtual ActionResult Admin()
    {
      Gebruiker gr = GebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));
      if (gr.isAdmin == false)
      {
        return Redirect("/home/index");
      }
      else
      {
        AdminModel model = new AdminModel()
        {
          FAQ = FyiMng.GetFAQs().OrderByDescending(f => f.GesteldOp).ToList(),
          Gebruikers = GebruikerMng.GetGebruikers().Where(g => g.isSuperAdmin == false).OrderBy(g => g.UserName).ToList()
        };
        return View(model);
      }

    }

    public virtual ActionResult SuperAdmin()
    {
      if (!User.Identity.IsAuthenticated)
      {
        return Redirect("/home/index");
      }
      else if (User.Identity.IsAuthenticated)
      {
        Gebruiker gebruiker = GebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));
        if (gebruiker.isSuperAdmin)
        {
          AdminModel model = new AdminModel()
          {
            FAQ = FyiMng.GetFAQs().OrderByDescending(f => f.GesteldOp).ToList(),
            Gebruikers = GebruikerMng.GetGebruikers().Where(g => g.isSuperAdmin == false).OrderBy(g => g.Email).ToList()
          };
          return View(model);
        }
        else
        {
          return Redirect("/home/index");
        }
      }
      return Redirect("/home/index");
    }
  }
}