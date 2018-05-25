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
   public class IngelogdeGebruikerController : ApiController
   {
      private GrafiekenManager grafiekenMng = new GrafiekenManager();
      private GebruikerManager gebruikerMng = new GebruikerManager();

      [Route("~/api/IngelogdeGebruiker/VerwijderGrafiek/{id}")]
      public IHttpActionResult GetVerwijderGrafiek(string id)
      {
         if (id.Equals("nodeBox"))
         {
            var gebruiker = gebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));
            gebruiker.NoNodebox = true;

            gebruikerMng.ChangeGebruiker(gebruiker);
            return Ok(true);
         }

         int intID;
         try
         {
            intID = int.Parse(id);
         }
         catch (Exception e)
         {
            return NotFound();
         }

         grafiekenMng.RemoveGrafiek(intID);
         return Ok(true);
      }

      [Route("~/api/IngelogdeGebruiker/WijzigGebruiker")]
      public IHttpActionResult PostWijzigGebruiker([FromBody] string data)
      {
         GebruikerJson gebruiker = JsonConvert.DeserializeObject<GebruikerJson>(data);

         Gebruiker g = gebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));

         g.Voornaam = gebruiker.voornaam;
         g.Achternaam = gebruiker.achternaam;
         g.Email = gebruiker.email;
         g.Geboortedatum = gebruiker.geboortedatum;
         g.Postcode = gebruiker.postcode;
         g.Beveiligingsvraag = gebruiker.vraag;
         g.Antwoord = gebruiker.antwoord;

         gebruikerMng.ChangeGebruiker(g);

         return Ok();
      }
      private AlertManager Alertmng = new AlertManager();
      [Route("~/api/IngelogdeGebruiker/alerttoevoegen")]
      public IHttpActionResult Postalerttoevoegen([FromBody] string data)
      {
         AlertJson alert = JsonConvert.DeserializeObject<AlertJson>(data);
         Gebruiker g = Alertmng.GetGebruiker(int.Parse(User.Identity.GetUserId()));

         Grafiek grafiek = Alertmng.GetGrafiek(int.Parse(alert.id));

         foreach (Persoon p in grafiek.Personen)
         {
            Alert a = new Alert()
            {
               Gebruiker = g,
               Type = Alert.AlertType.BEIDE,
               Persoon = p,
               Ingeschakeld = true,
               VerzendBrowser = true,
               VerzendMail = true
            };

            Alertmng.AddAlert(a);
         }

         return Ok();
      }
      
      [Route("~/api/IngelogdeGebruiker/Nodebox/{ingeschakeld}")]
      public IHttpActionResult PutNodebox(string ingeschakeld)
      {
         Gebruiker gebruiker = gebruikerMng.GetGebruiker(int.Parse(User.Identity.GetUserId()));

         if (ingeschakeld.Equals("true"))
         {
            gebruiker.NoNodebox = false;
         }
         else
         {
            gebruiker.NoNodebox = true;
         }

         gebruikerMng.ChangeGebruiker(gebruiker);

         return Ok(true);
      }

      [Route("~/api/IngelogdeGebruiker/EnableAlert/{enabled}/{id}")]
      public IHttpActionResult PutEnableAlert(string enabled, string id)
      {
         Alert alert = Alertmng.GetAlert(int.Parse(id));

         if (enabled.Equals("true"))
         {
            alert.Ingeschakeld = true;
         }
         else if(enabled.Equals("false"))
         {
            alert.Ingeschakeld = false;
         }

         Alertmng.ChangeAlert(alert);

         return Ok(true);
      }

      [Route("~/api/IngelogdeGebruiker/ChangeVerzendWijze/{wijze}/{enabled}/{id}")]
      public IHttpActionResult PutEnableAlert(string wijze, string enabled, string id)
      {
         Alert alert = Alertmng.GetAlert(int.Parse(id));

         if (enabled.Equals("true"))
         {
            if (wijze.Equals("mail"))
            {
               alert.VerzendMail = true;
            }else if (wijze.Equals("browser"))
            {
               alert.VerzendBrowser = true;
            }
         }
         else if(enabled.Equals("false"))
         {
            if (wijze.Equals("mail"))
            {
               alert.VerzendMail = false;
            }
            else if (wijze.Equals("browser"))
            {
               alert.VerzendBrowser = false;
            }
         }

         Alertmng.ChangeAlert(alert);

         return Ok(true);
      }
   }
}

public class GebruikerJson
{
   public string voornaam { get; set; }
   public string achternaam { get; set; }
   public string email { get; set; }
   public string geboortedatum { get; set; }
   public string postcode { get; set; }
   public string vraag { get; set; }
   public string antwoord { get; set; }
}

public class AlertJson
{
   public string id { get; set; }
}
