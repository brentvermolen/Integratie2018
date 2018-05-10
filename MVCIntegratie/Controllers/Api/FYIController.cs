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

      [Route("~/api/FYI/GetFAQ/{id}")]
      public IHttpActionResult GetFAQ(string id)
      {
         int intID;

         try
         {
            intID = int.Parse(id);
         }catch(Exception e)
         {
            return NotFound();
         }

         FAQ faq = FyiMng.GetFAQ(intID);
         if (faq == null)
         {
            return NotFound();
         }

         return Ok(faq);
      }

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

      [Route("~/api/FYI/VraagWijzigen")]
      public IHttpActionResult PostVraagWijzigen([FromBody]string data)
      {
         FAQAntwoordJson json = JsonConvert.DeserializeObject<FAQAntwoordJson>(data);

         FAQ faq = FyiMng.GetFAQ(json.id);
         faq.Beantwoord = json.beantwoord;
         if (json.beantwoord)
         {
            faq.BeantwoordOp = DateTime.Now;
         }
         else
         {
            faq.BeantwoordOp = faq.GesteldOp;
         }
         faq.Vraag = json.vraag;
         faq.Antwoord = json.antwoord;
         faq.Voorbeeld = json.voorbeeld;
         faq.Categorie = (FAQCategorie)json.categorie;

         FyiMng.EditFaq(faq);

         return Ok();
      }

      [Route("~/api/FYI/VraagVerwijderen")]
      public IHttpActionResult PostVraagVerwijderen([FromBody] string data)
      {
         FAQAntwoordJson f = JsonConvert.DeserializeObject<FAQAntwoordJson>(data);
         
         FyiMng.RemoveFaq(f.id);

         return Ok();
      }
   }
}

public class FAQJson
{
   public string vraag { get; set; }
   public int categorie { get; set; }
}

public class FAQAntwoordJson
{
   public int id { get; set; }
   public string vraag { get; set; }
   public int categorie { get; set; }
   public string antwoord { get; set; }
   public string voorbeeld { get; set; }
   public bool beantwoord { get; set; }
}