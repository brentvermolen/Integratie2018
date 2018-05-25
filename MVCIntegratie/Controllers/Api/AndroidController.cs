using BL;
using BL.Domain;
using BL.Domain.GrafiekTypes;
using Microsoft.AspNet.Identity;
using MVCIntegratie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCIntegratie.Controllers.Api
{
   public class AndroidController : ApiController
   {
      private AccountController accountController = new AccountController();

      public AndroidController()
      {
         UserMng = accountController.UserManager;
      }

      private GrafiekenManager GrafiekenMng = new GrafiekenManager();
      private DeelplatformManager PlatformMng = new DeelplatformManager();
      private GebruikerManager GebruikerMng = new GebruikerManager();

      private UserManager<MyUser, int> UserMng;
      private ApplicationSignInManager SignInManager;

      [Route("~/api/Android/Grafieken/{platform}/{id}")]
      public IHttpActionResult GetGrafieken(string platform, string id)
      {
         Deelplatform p = PlatformMng.GetDeelplatform(platform);

         if (int.Parse(id) == 0)
         {
            return Ok(GrafiekenMng.GetGrafieken().Where(g => g.Deelplatform.ID == p.ID && g.isDefault == true));
         }
         else
         {
            return Ok(GrafiekenMng.GetGrafieken().Where(g => g.Deelplatform.ID == p.ID && g.GebruikerId == int.Parse(id)));
         }
      }

      [Route("~/api/Android/Login/{gebruiker}/{wachtwoord}")]
      public IHttpActionResult GetLoginAsync(string gebruiker, string wachtwoord)
      {
         var user = UserMng.FindByName(gebruiker);
         
         if (UserMng.CheckPassword(user, wachtwoord))
         {
            return Ok(user);
         }
         else
         {
            return NotFound();
         }
      }
   }
}