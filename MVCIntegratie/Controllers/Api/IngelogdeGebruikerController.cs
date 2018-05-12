using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCIntegratie.Controllers.Api
{
   public class IngelogdeGebruikerController : ApiController
   {
      private GrafiekenManager grafiekenMng = new GrafiekenManager();

      [Route("~/api/IngelogdeGebruiker/VerwijderGrafiek/{id}")]
      public IHttpActionResult GetVerwijderGrafiek(string id)
      {
         int intID;
         try
         {
            intID = int.Parse(id);
         }catch(Exception e)
         {
            return NotFound();
         }

         grafiekenMng.RemoveGrafiek(intID);
         return Ok(true);
      }
   }
}
