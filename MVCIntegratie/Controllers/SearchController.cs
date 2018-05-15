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
using MVCIntegratie.Models;



namespace MVCIntegratie.Controllers
{
    public partial class SearchController : Controller
    {

        private IBerichtManager berichtMng = new BerichtManager();
        private IAlertManager alertMng = new AlertManager();
        private IGebruikerManager gebruikerMng = new GebruikerManager();
        private GrafiekenManager grafiekMng = new GrafiekenManager();



        // GET: Search
        public virtual ActionResult Index(FormCollection formCollection)
        {
            formCollection.AllKeys.ToString();
            string search = formCollection["search"];
            string filter = formCollection["Filter"];
            string sorter = formCollection["Sorteren"];

            List<Woord> woorden = new List<Woord>();
            List<Hashtag> hashtags = new List<Hashtag>();
            List<Mention> mentions = new List<Mention>();
            List<Url> urls = new List<Url>();
            List<Grafiek> grafieken = new List<Grafiek>();
            List<Persoon> personen = new List<Persoon>();
            string[] splitSearch = search.Split(' ');
            List<Bericht> berichten = new List<Bericht>();
            Bericht zoekresultaat = new Bericht();


            if (!filter.IsEmpty())
            {
                switch (filter)
                {
                    case "Politieker":
                        {
                            personen = berichtMng.GetPersonen().Where(p => p.Naam.ToLower().Contains(search.ToLower()))
.ToList();
                        }
                        break;
                    case "Tag":
                        {
                            foreach (string wrd in splitSearch)
                            {
                                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                                {
                                    continue;
                                }
                                else
                                {
                                    hashtags.AddRange(berichtMng.GetHashtags().Where(h => h.Tekst.ToLower().Contains(wrd.ToLower()))
                                        .ToList());
                                }
                            }
                        }
                        break;
                    case "Trefwoord":
                        {
                            foreach (string wrd in splitSearch)
                            {
                                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                                {
                                    continue;
                                }
                                else
                                {
                                    woorden.AddRange(berichtMng.GetWoorden().Where(w => w.Tekst.ToLower().Contains(wrd.ToLower()))
                                        .ToList());

                                }
                            }
                        }
                        break;
                    case "Mention":
                        {
                            foreach (string wrd in splitSearch)
                            {
                                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                                {
                                    continue;
                                }
                                else
                                {

                                    mentions.AddRange(berichtMng.GetMentions().Where(m => m.Tekst.ToLower().Contains(wrd.ToLower()))
                                        .ToList());

                                }
                            }

                        };
                        break;
                    case "Link":
                        {
                            foreach (string wrd in splitSearch)
                            {
                                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                                {
                                    continue;
                                }
                                else
                                {

                                    urls.AddRange(berichtMng.GetUrls().Where(u => u.Tekst.ToLower().Contains(wrd.ToLower()))
                                        .ToList());

                                }
                            }
                        };
                        break;
                    case "Grafiek":
                        {
                            foreach (string wrd in splitSearch)
                            {
                                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                                {
                                    continue;
                                }
                                else
                                {
                                    grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => g.Titel.ToLower().Contains(wrd.ToLower()))
                                       .ToList());
                                }
                            }
                        };
                        break;
                }


            }
            else
            {


                personen = berichtMng.GetPersonen().Where(p => p.Naam.ToLower().Contains(search.ToLower()))
             .ToList();









                foreach (string wrd in splitSearch)
                {
                    if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                    {
                        continue;
                    }
                    else
                    {
                        woorden.AddRange(berichtMng.GetWoorden().Where(w => w.Tekst.ToLower().Contains(wrd.ToLower()))
                            .ToList());
                        hashtags.AddRange(berichtMng.GetHashtags().Where(h => h.Tekst.ToLower().Contains(wrd.ToLower()))
                            .ToList());
                        mentions.AddRange(berichtMng.GetMentions().Where(m => m.Tekst.ToLower().Contains(wrd.ToLower()))
                            .ToList());
                        urls.AddRange(berichtMng.GetUrls().Where(u => u.Tekst.ToLower().Contains(wrd.ToLower()))
                            .ToList());
                        grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => g.Titel.ToLower().Contains(wrd.ToLower()))
                            .ToList());
                    }
                }

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