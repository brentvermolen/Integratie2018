using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using BL.Interfaces;

namespace MVCIntegratie.Controllers
{
    public partial class SearchController : Controller
    {

        private IBerichtManager berichtMng = new BerichtManager();
        private IAlertManager alertMng = new AlertManager();
        private IGebruikerManager gebruikerMng = new GebruikerManager();


        
        // GET: Search
        public virtual ActionResult Index(string search)
        {
            if (!search.IsEmpty() || search!=null)
            {
                return RedirectToAction("Search");
            }
            else
            {
                return View();
            }

        }

        public virtual ActionResult Search(string search)
        {
            if (search == null)
            {
                return PartialView("_Resultaat");
            }

            List<Persoon> personen = berichtMng.GetPersonen().Where(p => p.Naam.ToLower().Contains(search.ToLower()))
                .ToList();


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
                woorden.AddRange(berichtMng.GetWoorden().Where(w => w.Tekst.ToLower().Contains(wrd.ToLower()))
                    .ToList());
                hashtags.AddRange(berichtMng.GetHashtags().Where(h => h.Tekst.ToLower().Contains(wrd.ToLower()))
                    .ToList());
                mentions.AddRange(berichtMng.GetMentions().Where(m => m.Tekst.ToLower().Contains(wrd.ToLower()))
                    .ToList());
                urls.AddRange(berichtMng.GetUrls().Where(u => u.Tekst.ToLower().Contains(wrd.ToLower())).ToList());
            }

            //personen.Sort();
            zoekresultaat.Woorden = woorden;
            zoekresultaat.Hashtags = hashtags;
            zoekresultaat.Mentions = mentions;
            zoekresultaat.Personen = personen;
            zoekresultaat.Urls = urls;
            //Sortering testSortering = new Sortering();



            woorden.ToString();
            return PartialView("_Resultaat",zoekresultaat);
        }
    }
}