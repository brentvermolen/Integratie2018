using BL;
using BL.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCIntegratie.Controllers.Api
{
   public class FYIController : ApiController
   {
      private FYIManager FyiMng = new FYIManager();

      [Route("~/api/FYI/VraagOpslaan")]
      public IHttpActionResult Post([FromBody]string data)
      {
         FAQJson json = JsonConvert.DeserializeObject<FAQJson>(data);

         FAQ faq = new FAQ()
         {
            Vraag = json.vraag,
            Categorie = (FAQCategorie)json.categorie
         };

         FyiMng.AddFaq(faq);

         return Ok();
      }
   }

   public class FAQJson
   {
      public string vraag { get; set; }
      public int categorie { get; set; }
   }
}
