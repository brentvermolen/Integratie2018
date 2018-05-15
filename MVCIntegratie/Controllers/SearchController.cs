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
using Microsoft.AspNet.Identity;



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
            ZoekResultaat zoekResultaat = new ZoekResultaat();


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
                                    grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => g.GebruikerId.Equals(int.Parse(this.User.Identity.GetUserId())) && g.Titel.ToLower().Contains(wrd.ToLower()))
                                            .ToList());
                                    foreach (Persoon persoon in personen)
                                    {
                                        grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => g.GebruikerId.Equals(int.Parse(this.User.Identity.GetUserId())) && g.Personen.Contains(persoon))
                                           .ToList());

                                    }
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
                        grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => g.GebruikerId.Equals(int.Parse(this.User.Identity.GetUserId())) && g.Titel.ToLower().Contains(wrd.ToLower()))
                          .ToList());
                        foreach (Persoon persoon in personen)
                        {
                            grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => g.GebruikerId.Equals(int.Parse(this.User.Identity.GetUserId())) && g.Personen.Contains(persoon))
                               .ToList());

                        }

                    }
                }

            }

            zoekResultaat.Woorden = woorden;
            zoekResultaat.Hashtags = hashtags;
            zoekResultaat.Mentions = mentions;
            zoekResultaat.Personen = personen;
            zoekResultaat.Urls = urls;
            zoekResultaat.Grafieken = grafieken;

            switch (sorter)
            {
                case "AantalBerichten":
                    {
                        zoekResultaat.Woorden.Sort();
                        zoekResultaat.Hashtags.Sort();
                        zoekResultaat.Mentions.Sort();
                        zoekResultaat.Personen.Sort((p1, p2) => p1.Berichten.Count().CompareTo(p2.Berichten.Count()));
                        zoekResultaat.Urls.Sort();
                    }; break;
                case "Naam":
                    {
                        zoekResultaat.Woorden.Sort((w1, w2) => w1.Tekst.CompareTo(w2.Tekst));
                        zoekResultaat.Hashtags.Sort((h1, h2) => h1.Tekst.CompareTo(h2.Tekst));
                        zoekResultaat.Mentions.Sort((m1, m2) => m1.Tekst.CompareTo(m2.Tekst));
                        zoekResultaat.Urls.Sort((u1, u2) => u1.Tekst.CompareTo(u2.Tekst));
                        zoekResultaat.Personen.Sort((p1, p2) => p1.Naam.CompareTo(p2.Naam));

                    };
                    break;

                default:
                    {
                        zoekResultaat.Woorden.Sort();
                        zoekResultaat.Hashtags.Sort();
                        zoekResultaat.Mentions.Sort();
                        zoekResultaat.Personen.Sort((p1, p2) => p1.Berichten.Count().CompareTo(p2.Berichten.Count()));
                        zoekResultaat.Urls.Sort();
                    };
                    break;
            }


            woorden.ToString();
            return View(zoekResultaat);
        }


    }
}