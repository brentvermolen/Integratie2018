using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCIntegratie
{
   public class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(
             name: "Deelplatformen",
             url: "{language}/{deelplatform}/{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, language = "nl-BE" }
         );

         routes.MapRoute(
             name: "Default",
             url: "{language}/{controller}/{action}/{id}",
             defaults: new { controller = "Deelplatform", action = "Index", id = UrlParameter.Optional, language = "nl-BE" }
         );
      }
   }
}
