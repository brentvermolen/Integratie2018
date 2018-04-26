﻿using BL;
using BL.Domain;
using BL.Domain.AlertKlassen;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using BL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace MVCIntegratie.Controllers
{
    [RequireHttps]
    public partial class HomeController : Controller

    {
        private IBerichtManager berichtMng = new BerichtManager();
        private IAlertManager alertMng = new AlertManager();
        private IGebruikerManager gebruikerMng = new GebruikerManager();

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Zoek(string search)
        {
            if (search == null)
            {
                return View();
            }
        
            List<Persoon> personen = berichtMng.GetPersonen().Where(p => p.Naam.Contains(search)).ToList();


            string[] splitSearch = search.Split(' ');
            List<Woord> woorden = new List<Woord>();
            List<Hashtag> hashtags = new List<Hashtag>();
            List<Mention> mentions = new List<Mention>();
            List<Url> urls = new List<Url>();
            // List<Thema> themas = new List<Thema>();

            List<Bericht> berichten = new List<Bericht>();

            foreach (string wrd in splitSearch)
            {
                woorden.AddRange(berichtMng.GetWoorden().Where(w => w.Tekst.Contains(wrd)).ToList());
                hashtags.AddRange(berichtMng.GetHashtags().Where(h => h.Tekst.Contains(wrd)).ToList());
                mentions.AddRange(berichtMng.GetMentions().Where(m => m.Tekst.Contains(wrd)).ToList());
                urls.AddRange(berichtMng.GetUrls().Where(u => u.Tekst.Contains(wrd)).ToList());
            }

            
            /*
            foreach (var persoon in personen)
            {
                berichten.AddRange(persoon.Berichten);
            }

            foreach (var woord in woorden)
            {
                berichten.AddRange(woord.Berichten);
            }

            foreach (var hashtag in hashtags)
            {
                berichten.AddRange(hashtag.Berichten);
            }

            foreach (var mention in mentions)
            {
               berichten.AddRange(mention.Berichten); 
            }

            foreach (var url in urls)
            {
                berichten.AddRange(url.Berichten);
            }*/

            woorden.ToString();
            return View(personen);
        }
    }
}