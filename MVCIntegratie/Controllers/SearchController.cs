using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using MVCIntegratie.Models;
using Microsoft.AspNet.Identity;
using BL.Domain.PersoonKlassen;

namespace MVCIntegratie.Controllers
{
    public partial class SearchController : Controller
    {

        private BerichtManager berichtMng = new BerichtManager();
        private AlertManager alertMng = new AlertManager();
        private GebruikerManager gebruikerMng = new GebruikerManager();
        private GrafiekenManager grafiekMng = new GrafiekenManager();



        // GET: Search
        public virtual ActionResult Index(FormCollection formCollection)
        {
            formCollection.AllKeys.ToString();
            string search = formCollection["search"];
            string filter = formCollection["Filter"];
            string sorter = formCollection["Sorteren"];
            string startDate = formCollection["startDate"];
            string endDate = formCollection["endDate"];
            string postcode = formCollection["postcode"];
            if ((formCollection["trending"]) != null)
            {
                bool trending = Convert.ToBoolean(formCollection["trending"].Split(',')[0]);
            }

            List<Bericht> berichten = new List<Bericht>();
            ZoekResultaat zoekResultaat = new ZoekResultaat();

            if (startDate.IsEmpty() || startDate == null)
            {
                startDate = "2015-01-01";
            }
            if (endDate.IsEmpty() || endDate == null)
            {
                endDate = DateTime.Now.ToShortDateString();
            }

            if (search == null)
            {
                search = "";
            }
            if (postcode.IsEmpty())
            {
                postcode = null;
            }
            if (postcode != null)
            {
                switch (filter)
                {
                    case "Politieker":
                        {

                            zoekResultaat.Personen = zoekPersonen(search, startDate, endDate, postcode);


                        }
                        break;
                    case "Tag":
                        {

                            zoekResultaat.Hashtags = zoekHashtags(search, startDate, endDate, postcode);

                        }
                        break;
                    case "Trefwoord":
                        {
                            zoekResultaat.Woorden = zoekWoorden(search, startDate, endDate, postcode);


                        }
                        break;
                    case "Mention":
                        {

                            zoekResultaat.Mentions = zoekMentions(search, startDate, endDate, postcode);



                        };
                        break;
                    case "Link":
                        {

                            zoekResultaat.Urls = zoekUrls(search, startDate, endDate, postcode);


                        };
                        break;
                    case "Grafiek":
                        {

                            zoekResultaat.Grafieken = zoekGrafieken(search, startDate, endDate, postcode);

                        };
                        break;
                    case "Organisatie":
                        {
                            zoekResultaat.Organisaties = zoekOrganisaties(search, startDate, endDate, postcode);
                        }
                        break;
                    default:
                        {
                            zoekResultaat.Woorden = zoekWoorden(search, startDate, endDate, postcode);
                            zoekResultaat.Hashtags = zoekHashtags(search, startDate, endDate, postcode);
                            zoekResultaat.Mentions = zoekMentions(search, startDate, endDate, postcode);
                            zoekResultaat.Personen = zoekPersonen(search, startDate, endDate, postcode);
                            zoekResultaat.Urls = zoekUrls(search, startDate, endDate, postcode);
                            zoekResultaat.Grafieken = zoekGrafieken(search, startDate, endDate, postcode);
                            zoekResultaat.Organisaties = zoekOrganisaties(search, startDate, endDate, postcode);
                        }
                        break;
                }
            }
            else
            {



                switch (filter)
                {
                    case "Politieker":
                        {

                            zoekResultaat.Personen = zoekPersonen(search, startDate, endDate);


                        }
                        break;
                    case "Tag":
                        {

                            zoekResultaat.Hashtags = zoekHashtags(search, startDate, endDate);

                        }
                        break;
                    case "Trefwoord":
                        {
                            zoekResultaat.Woorden = zoekWoorden(search, startDate, endDate);


                        }
                        break;
                    case "Mention":
                        {

                            zoekResultaat.Mentions = zoekMentions(search, startDate, endDate);



                        };
                        break;
                    case "Link":
                        {

                            zoekResultaat.Urls = zoekUrls(search, startDate, endDate);


                        };
                        break;
                    case "Grafiek":
                        {

                            zoekResultaat.Grafieken = zoekGrafieken(search, startDate, endDate);

                        };
                        break;
                    case "Organisatie":
                        {
                            zoekResultaat.Organisaties = zoekOrganisaties(search, startDate, endDate);
                        }
                        break;
                    default:
                        {
                            zoekResultaat.Woorden = zoekWoorden(search, startDate, endDate);
                            zoekResultaat.Hashtags = zoekHashtags(search, startDate, endDate);
                            zoekResultaat.Mentions = zoekMentions(search, startDate, endDate);
                            zoekResultaat.Personen = zoekPersonen(search, startDate, endDate);
                            zoekResultaat.Urls = zoekUrls(search, startDate, endDate);
                            zoekResultaat.Grafieken = zoekGrafieken(search, startDate, endDate);
                            zoekResultaat.Organisaties = zoekOrganisaties(search, startDate, endDate);
                        }
                        break;
                }
            }

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

            zoekResultaat.ToString();
            return View(zoekResultaat);
        }
        [NonAction]
        public List<Woord> zoekWoorden(String search, string startDate, string endDate)
        {
            string[] splitSearch = search.Split(' ');
            List<Woord> woorden = new List<Woord>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {

                    woorden.AddRange(berichtMng.GetWoorden().Where(w => w.Tekst.ToLower().Contains(wrd.ToLower()) && w.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null)
                         .ToList());



                }
            }



            return woorden;
        }
        [NonAction]
        public List<Organisatie> zoekOrganisaties(String search, String startDate, String endDate)
        {
            string[] splitSearch = search.Split(' ');
            List<Organisatie> organisaties = new List<Organisatie>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {
                    organisaties.AddRange(berichtMng.getOrganisaties().Where(o => o.Naam.ToLower().Contains(wrd.ToLower()) && o.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null) != null)
                          .ToList());
                    List<Persoon> personen = zoekPersonen(search, startDate, endDate);
                    foreach (Persoon persoon in personen)
                    {
                        List<Organisatie> organTussen = berichtMng.getOrganisaties().Where(o => o.Personen.Contains(persoon) && o.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null) != null)
                          .ToList();
                        foreach (Organisatie org in organTussen)
                        {
                            if (organisaties.Contains(org))
                            {
                                continue;
                            }
                            else
                            {
                                organisaties.Add(org);
                            }
                        }
                    }
                }
            }
            return organisaties;

        }

        [NonAction]
        public List<Hashtag> zoekHashtags(String search, String startDate, String endDate)
        {
            string[] splitSearch = search.Split(' ');
            List<Hashtag> hashtags = new List<Hashtag>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {
                    hashtags.AddRange(berichtMng.GetHashtags().Where(h => h.Tekst.ToLower().Contains(wrd.ToLower()) && h.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null)
                          .ToList());
                }
            }

            return hashtags;
        }

        [NonAction]
        public List<Mention> zoekMentions(String search, String startDate, String endDate)
        {
            string[] splitSearch = search.Split(' ');
            List<Mention> mentions = new List<Mention>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {

                    mentions.AddRange(berichtMng.GetMentions().Where(m => m.Tekst.ToLower().Contains(wrd.ToLower()) && m.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null)
                          .ToList());


                }
            }
            return mentions;
        }
        [NonAction]
        public List<Url> zoekUrls(String search, String startDate, String endDate)
        {
            string[] splitSearch = search.Split(' ');
            List<Url> urls = new List<Url>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {

                    urls.AddRange(berichtMng.GetUrls().Where(u => u.Tekst.ToLower().Contains(wrd.ToLower()) && u.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null)
                          .ToList());
                }
            }
            return urls;
        }
        [NonAction]
        public List<Grafiek> zoekGrafieken(String search, String startDate, String endDate)
        {
            int userId = -1;
            if (this.User.Identity.IsAuthenticated)
            {
                userId = int.Parse(this.User.Identity.GetUserId());
            }
            string[] splitSearch = search.Split(' ');
            List<Grafiek> grafieken = new List<Grafiek>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {
                    if (userId == -1)
                    {
                        grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => g.isDefault && g.Titel.ToLower().Contains(wrd.ToLower()) && g.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null) != null)
                              .ToList());
                        List<Persoon> personen = zoekPersonen(search, startDate, endDate);
                        foreach (Persoon persoon in personen)
                        {
                            List<Grafiek> grafiekTussen = grafiekMng.GetGrafieken().Where(g => g.isDefault && g.Personen.Contains(persoon) && g.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null) != null)
                              .ToList();
                            foreach (Grafiek gr in grafiekTussen)
                            {
                                if (grafieken.Contains(gr))
                                {
                                    continue;
                                }
                                else
                                {
                                    grafieken.Add(gr);
                                }
                            }



                        }

                    }
                    else
                    {
                        grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => (g.GebruikerId.Equals(userId) || g.isDefault) && g.Titel.ToLower().Contains(wrd.ToLower()) && g.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null) != null)
                              .ToList());
                        List<Persoon> personen = zoekPersonen(search, startDate, endDate);
                        foreach (Persoon persoon in personen)
                        {
                            List<Grafiek> grafiekTussen = grafiekMng.GetGrafieken().Where(g => (g.GebruikerId.Equals(userId) || g.isDefault) && g.Personen.Contains(persoon) && g.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null) != null)
                              .ToList();
                            foreach (Grafiek gr in grafiekTussen)
                            {
                                if (grafieken.Contains(gr))
                                {
                                    continue;
                                }
                                else
                                {
                                    grafieken.Add(gr);
                                }
                            }



                        }
                    }
                }
            }
            return grafieken;
        }
        [NonAction]
        public List<Persoon> zoekPersonen(String search, String startDate, String endDate)
        {
            List<Persoon> personen = berichtMng.GetPersonen().Where(p => p.Naam.ToLower().Contains(search.ToLower()) /*&& p.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null*/)
                          .ToList();

            return personen;
        }

        [NonAction]
        public List<Woord> zoekWoorden(String search, string startDate, string endDate, string postcode)
        {
            string[] splitSearch = search.Split(' ');
            List<Woord> woorden = new List<Woord>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {

                    woorden.AddRange(berichtMng.GetWoorden().Where(w => w.Tekst.ToLower().Contains(wrd.ToLower()) && w.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null
                    && w.Berichten.Where(b => b.Personen.Where(p => p.Postcode.Equals(postcode)) != null) != null)
                         .ToList());



                }
            }



            return woorden;
        }
        [NonAction]
        public List<Hashtag> zoekHashtags(String search, String startDate, String endDate, string postcode)
        {
            string[] splitSearch = search.Split(' ');
            List<Hashtag> hashtags = new List<Hashtag>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {
                    hashtags.AddRange(berichtMng.GetHashtags().Where(h => h.Tekst.ToLower().Contains(wrd.ToLower()) && h.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null
                    && h.Berichten.Where(b => b.Personen.Where(p => p.Postcode.Equals(postcode)) != null) != null)
                          .ToList());
                }
            }

            return hashtags;
        }

        [NonAction]
        public List<Mention> zoekMentions(String search, String startDate, String endDate, string postcode)
        {
            string[] splitSearch = search.Split(' ');
            List<Mention> mentions = new List<Mention>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {

                    mentions.AddRange(berichtMng.GetMentions().Where(m => m.Tekst.ToLower().Contains(wrd.ToLower()) && m.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null
                    && m.Berichten.Where(b => b.Personen.Where(p => p.Postcode.Equals(postcode)) != null) != null)
                          .ToList());


                }
            }
            return mentions;
        }
        [NonAction]
        public List<Url> zoekUrls(String search, String startDate, String endDate, string postcode)
        {
            string[] splitSearch = search.Split(' ');
            List<Url> urls = new List<Url>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {

                    urls.AddRange(berichtMng.GetUrls().Where(u => u.Tekst.ToLower().Contains(wrd.ToLower()) && u.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null
                    && u.Berichten.Where(b => b.Personen.Where(p => p.Postcode.Equals(postcode)) != null) != null)
                          .ToList());
                }
            }
            return urls;
        }
        [NonAction]
        public List<Grafiek> zoekGrafieken(String search, String startDate, String endDate, string postcode)
        {
            int userId = -1;
            if (this.User.Identity.IsAuthenticated)
            {
                userId = int.Parse(this.User.Identity.GetUserId());
            }
            string[] splitSearch = search.Split(' ');
            List<Grafiek> grafieken = new List<Grafiek>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {
                    if (userId == -1)
                    {
                        grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => g.isDefault
                       && g.Titel.ToLower().Contains(wrd.ToLower())
                       && g.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate)
                       && b.Datum < DateTime.Parse(endDate)) != null) != null
                       && g.Personen.Where(p => p.Postcode.Equals(postcode)) != null)
                             .ToList());
                        List<Persoon> personen = zoekPersonen(search, startDate, endDate, postcode);
                        foreach (Persoon persoon in personen)
                        {
                            List<Grafiek> grafiekTussen = grafiekMng.GetGrafieken().Where(g => g.isDefault
                            && g.Personen.Contains(persoon) && g.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate)
                            && b.Datum < DateTime.Parse(endDate)) != null) != null
                            && g.Personen.Where(p => p.Postcode.Equals(postcode)) != null)
                              .ToList();
                            foreach (Grafiek gr in grafiekTussen)
                            {
                                if (grafieken.Contains(gr))
                                {
                                    continue;
                                }
                                else
                                {
                                    grafieken.Add(gr);
                                }
                            }



                        }

                    }
                    else
                    {
                        grafieken.AddRange(grafiekMng.GetGrafieken().Where(g => (g.GebruikerId.Equals(userId) || g.isDefault)
                        && g.Titel.ToLower().Contains(wrd.ToLower())
                        && g.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate)
                        && b.Datum < DateTime.Parse(endDate)) != null) != null
                        && g.Personen.Where(p => p.Postcode.Equals(postcode)) != null)
                              .ToList());
                        List<Persoon> personen = zoekPersonen(search, startDate, endDate, postcode);
                        foreach (Persoon persoon in personen)
                        {
                            List<Grafiek> grafiekTussen = grafiekMng.GetGrafieken().Where(g => (g.GebruikerId.Equals(userId) || g.isDefault)
                            && g.Personen.Contains(persoon) && g.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate)
                            && b.Datum < DateTime.Parse(endDate)) != null) != null
                            && g.Personen.Where(p => p.Postcode.Equals(postcode)) != null)
                              .ToList();
                            foreach (Grafiek gr in grafiekTussen)
                            {
                                if (grafieken.Contains(gr))
                                {
                                    continue;
                                }
                                else
                                {
                                    grafieken.Add(gr);
                                }
                            }



                        }
                    }
                }
            }
            return grafieken;
        }
        [NonAction]
        public List<Persoon> zoekPersonen(String search, String startDate, String endDate, string postcode)
        {
            List<Persoon> personen = berichtMng.GetPersonen().Where(p => p.Naam.ToLower().Contains(search.ToLower()) && p.Postcode.Equals(postcode)
            && p.Berichten.FirstOrDefault(b => b.Datum > DateTime.Parse(startDate) && b.Datum < DateTime.Parse(endDate)) != null)
                          .ToList();

            return personen;
        }

        [NonAction]
        public List<Organisatie> zoekOrganisaties(String search, String startDate, String endDate, String postcode)
        {
            string[] splitSearch = search.Split(' ');
            List<Organisatie> organisaties = new List<Organisatie>();
            foreach (string wrd in splitSearch)
            {
                if (wrd.ToLower().Equals("de") || wrd.ToLower().Equals("van") || wrd.ToLower().Equals("een") || wrd.ToLower().Equals("het"))
                {
                    continue;
                }
                else
                {
                    organisaties.AddRange(berichtMng.getOrganisaties()
                        .Where(o => o.Naam.ToLower().Contains(wrd.ToLower())
                    && o.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate)
                    && b.Datum < DateTime.Parse(endDate)) != null) != null
                    && o.Personen.Where(p => p.Postcode.Equals(postcode)) != null)
                          .ToList());
                    List<Persoon> personen = zoekPersonen(search, startDate, endDate, postcode);
                    foreach (Persoon persoon in personen)
                    {
                        List<Organisatie> organTussen = berichtMng.getOrganisaties()
                            .Where(o => o.Personen.Contains(persoon)
                            && o.Personen.Where(p => p.Berichten.Where(b => b.Datum > DateTime.Parse(startDate)
                            && b.Datum < DateTime.Parse(endDate)) != null) != null
                            && o.Personen.Where(p => p.Postcode.Equals(postcode)) != null)
                          .ToList();
                        foreach (Organisatie org in organTussen)
                        {
                            if (organisaties.Contains(org))
                            {
                                continue;
                            }
                            else
                            {
                                organisaties.Add(org);
                            }
                        }
                    }
                }
            }
            return organisaties;

        }


    }
}