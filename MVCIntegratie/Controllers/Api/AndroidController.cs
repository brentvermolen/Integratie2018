using BL;
using BL.Domain.GrafiekTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCIntegratie.Controllers.Api
{
   public class AndroidController : ApiController
   {
      private GrafiekenManager GrafiekenMng = new GrafiekenManager();

      [Route("~/api/Android/Grafieken/{id}")]
      public IHttpActionResult GetGrafieken(string id)
      {
         return Ok(GrafiekenMng.GetGrafieken().Where(g => g.GebruikerId == int.Parse(id)));
      }
   }
}