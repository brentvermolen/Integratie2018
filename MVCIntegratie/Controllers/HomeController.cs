using BL;
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

        public virtual ActionResult Home_Ingelogd()
        {
            return View();
        }

        public virtual ActionResult Index()
      {
         List<Bericht> oudeBerichten = berichtMng.GetBerichten().ToList();
         List<Bericht> nieuweBerichten = berichtMng.LeesBerichten(10, "Annick De Ridder").ToList();



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
        
            List<Persoon> personen = berichtMng.GetPersonen().Where(p => p.Naam.ToLower().Contains(search.ToLower())).ToList();


            string[] splitSearch = search.Split(' ');
            List<Woord> woorden = new List<Woord>();
            List<Hashtag> hashtags = new List<Hashtag>();
            List<Mention> mentions = new List<Mention>();
            List<Url> urls = new List<Url>();
            // List<Thema> themas = new List<Thema>();

            List<Bericht> berichten = new List<Bericht>();
            Bericht zoekresultaat = new Bericht();
            foreach (string wrd in splitSearch)
            {
                woorden.AddRange(berichtMng.GetWoorden().Where(w => w.Tekst.ToLower().Contains(wrd.ToLower())).ToList());
                hashtags.AddRange(berichtMng.GetHashtags().Where(h => h.Tekst.ToLower().Contains(wrd.ToLower())).ToList());
                mentions.AddRange(berichtMng.GetMentions().Where(m => m.Tekst.ToLower().Contains(wrd.ToLower())).ToList());
                urls.AddRange(berichtMng.GetUrls().Where(u => u.Tekst.ToLower().Contains(wrd.ToLower())).ToList());
            }


            zoekresultaat.Woorden = woorden;
            zoekresultaat.Hashtags = hashtags;
            zoekresultaat.Mentions = mentions;
            zoekresultaat.Personen = personen;
            zoekresultaat.Urls = urls;
            
           

            woorden.ToString();
            return View(zoekresultaat);
        }
    }
}