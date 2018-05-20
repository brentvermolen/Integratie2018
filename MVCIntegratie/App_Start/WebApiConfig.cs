using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MVCIntegratie.App_Start
{
   public static class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {
         config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

         config.MapHttpAttributeRoutes();

         config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional });
      }
   }
}