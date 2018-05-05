using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace MVCIntegratie.Controllers
{
   [RequireHttps]
    public partial class HomeController : Controller
   { 
      private IBerichtManager berichtMng = new BerichtManager();
      private IAlertManager alertMng = new AlertManager();
      private IGebruikerManager gebruikerMng = new GebruikerManager();
      private GrafiekenManager grafiekenMng = new GrafiekenManager();

      public virtual ActionResult Home_Ingelogd()
      {
         return View();
      }

      public virtual ActionResult Index()
      {
         int count = 0;
         List<Grafiek> graf = grafiekenMng.GetGrafieken().Where(g => count++ < 10).ToList();

         return View(graf);
      }

      public class AantalTweetsPerWeek
      {
         public int Count { get; set; }
         public DateTime Week { get; set; }
      }

      public virtual ActionResult Zoek(string search)
      {
         if (search == null)
         {
            return View();
         }

         List<Persoon> personen = berichtMng.GetPersonen().Where(p => p.Naam.Contains(search)).ToList();

         List<Gebruiker> gebruikers = gebruikerMng.GetGebruikers().ToList();

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
            return View(zoekresultaat);
        }

      /* private class Sortering
       {
           public ArrayList sortedWoorden { get; set; }
           public ArrayList sortedPersonen { get; set; }
           public ArrayList sortedMentions { get; set; }
           public ArrayList sortedHastags { get; set; }
           public ArrayList sortedUrls { get; set; }
       }*/

      public virtual ActionResult Toevoegen(string type)
      {
         Grafiek graf = new Bar(0, "PREVIEW", new As() { IsUsed = true, Categorieen = new List<Categorie>() }, new List<Serie>());
         graf.xAs.Categorieen.Add(new Categorie("Objectiviteit"));
         graf.xAs.Categorieen.Add(new Categorie("Polariteit"));

         List<Persoon> personen = berichtMng.GetPersonen().ToList();
         personen.Sort((p1, p2) => p1.Naam.CompareTo(p2.Naam));

         return View("GrafiekToevoegen", new GrafiekPersonen() { Grafiek = graf, Personen = personen });
      }
   }
}