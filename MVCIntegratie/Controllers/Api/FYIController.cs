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
      private GebruikerManager gebruikermngr = new GebruikerManager();
      private DeelplatformManager platformMng = new DeelplatformManager();

      [Route("~/api/FYI/GetFAQ/{id}")]
      public IHttpActionResult GetFAQ(string id)
      {
         int intID;

         try
         {
            intID = int.Parse(id);
         }
         catch (Exception e)
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

         Deelplatform platform = platformMng.GetDeelplatform(json.deelplatform);

         if (platform == null)
         {
            return NotFound();
         }

         FAQ faq = new FAQ()
         {
            Vraag = json.vraag,
            Categorie = (FAQCategorie)json.categorie,
            DeelplatformID = platform.ID
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

      [Route("~/api/FYI/GebruikerWijzigen")]
      public IHttpActionResult PostGebruikerWijzigen([FromBody] string data)
      {
         WijzigGebruiker gebruiker = JsonConvert.DeserializeObject<WijzigGebruiker>(data);

         Gebruiker g = platformMng.GetGebruiker(gebruiker.id);

         g.Email = gebruiker.email;
         if (gebruiker.isAdmin)
         {
            g.IsAdmin.Add(platformMng.GetDeelplatform(gebruiker.deelplatform));
         }
         else
         {
            g.IsAdmin.Remove(platformMng.GetDeelplatform(gebruiker.deelplatform));
         }

         platformMng.ChangeObject(g);

         return Ok();
      }

      [Route("~/api/FYI/GetGebruiker/{id}")]
      public IHttpActionResult GetGebruiker(string id)
      {
         int intID;

         try
         {
            intID = int.Parse(id);
         }
         catch (Exception e)
         {
            return NotFound();
         }

         Gebruiker g = gebruikermngr.GetGebruiker(intID);

         return Ok(g);
      }

      private BerichtManager BerichtMng = new BerichtManager();

      [Route("~/api/FYI/GetPersoon/{id}")]
      public IHttpActionResult GetPersoon(string id)
      {
         int intID;

         try
         {
            intID = int.Parse(id);
         }
         catch (Exception e)
         {
            return NotFound();
         }

         Persoon p = BerichtMng.GetPersoon(intID);

         return Ok(p);
      }

      [Route("~/api/FYI/GebruikerBlokkeren")]
      public IHttpActionResult PostGebruikerBlokkeren([FromBody] string data)
      {
         WijzigGebruiker gebruiker = JsonConvert.DeserializeObject<WijzigGebruiker>(data);

         Gebruiker g = gebruikermngr.GetGebruiker(gebruiker.id);

         g.LockoutEnabled = true;
         g.LockoutEndDateUtc = new DateTime(2150, 1, 1);

         gebruikermngr.ChangeGebruiker(g);

         return Ok();
      }

      [Route("~/api/FYI/GebruikerActiveren")]
      public IHttpActionResult PostGebruikerActiveren([FromBody] string data)
      {
         WijzigGebruiker gebruiker = JsonConvert.DeserializeObject<WijzigGebruiker>(data);

         Gebruiker g = gebruikermngr.GetGebruiker(gebruiker.id);

         g.LockoutEnabled = false;
         g.LockoutEndDateUtc = null;

         gebruikermngr.ChangeGebruiker(g);

         return Ok();
      }

      [Route("~/api/FYI/PersoonBlokkeren")]
      public IHttpActionResult PostPersoonBlokkeren([FromBody] string data)
      {
         WijzigPersoon persoon = JsonConvert.DeserializeObject<WijzigPersoon>(data);

         Persoon p = BerichtMng.GetPersoon(persoon.id);

         p.Disabled = true;

         BerichtMng.ChangePersoon(p);

         return Ok();
      }

      [Route("~/api/FYI/PersoonActiveren")]
      public IHttpActionResult PostPersoonActiveren([FromBody] string data)
      {
         WijzigPersoon persoon = JsonConvert.DeserializeObject<WijzigPersoon>(data);

         Persoon p = BerichtMng.GetPersoon(persoon.id);

         p.Disabled = false;

         BerichtMng.ChangePersoon(p);

         return Ok();
      }

      [Route("~/api/FYI/ContactOpslaan")]
      public IHttpActionResult PostContact([FromBody]string data)
      {
         ContactJson json = JsonConvert.DeserializeObject<ContactJson>(data);

         Deelplatform platform = platformMng.GetDeelplatform(json.deelplatform);

         if (platform == null)
         {
            return NotFound();
         }

         Contact contact = new Contact()
         {
            Email = json.email,
            Naam = json.naam,
            Onderwerp = json.onderwerp,
            Bericht = json.bericht,
            DeelplatformID = platform.ID
         };

         FyiMng.AddContact(contact);

         return Ok();
      }
   }
}

public class ContactJson
{
   public string email { get; set; }
   public string naam { get; set; }
   public string onderwerp { get; set; }
   public string bericht { get; set; }
   public string deelplatform { get; set; }
}

public class WijzigGebruiker
{
   public int id { get; set; }
   public string email { get; set; }
   public bool isAdmin { get; set; }
   public string deelplatform { get; set; }
}

public class WijzigPersoon
{
   public int id { get; set; }
   public string deelplatform { get; set; }
}

public class FAQJson
{
   public string vraag { get; set; }
   public int categorie { get; set; }
   public string deelplatform { get; set; }
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