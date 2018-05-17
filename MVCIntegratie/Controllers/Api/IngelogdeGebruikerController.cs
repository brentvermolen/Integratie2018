﻿using BL;
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
            //Verwijder NodeBox grafiek
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