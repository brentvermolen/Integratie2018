using BL;
using BL.Domain;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCIntegratie.Controllers.Api
{
   public class ConfigController : ApiController
   {
      private DeelplatformManager PlatformMng = new DeelplatformManager();

      [Route("~/api/Config/RegistreerDeelplatform")]
      public IHttpActionResult PostRegistreerDeelplatform([FromBody] string data)
      {
         DeelplatformJson platform = JsonConvert.DeserializeObject<DeelplatformJson>(data);

         Gebruiker gebruiker = PlatformMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));
         Deelplatform deelplatform = PlatformMng.GetDeelplatform(platform.id);

         gebruiker.Deelplatformen.Add(deelplatform);
         PlatformMng.ChangeObject(gebruiker);

         return Ok();
      }

      public class DeelplatformJson
      {
         public int id { get; set; }
      }
   }
}
