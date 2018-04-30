using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.ItemKlassen;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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

         woorden.ToString();
         return View(personen);
      }

      public virtual ActionResult Toevoegen(string type)
      {
         Grafiek graf = new Bar(0, "PREVIEW", new As() { IsUsed = true, Categorieën = new List<Categorie>() }, new List<Serie>());
         graf.xAs.Categorieën.Add(new Categorie("Objectiviteit"));
         graf.xAs.Categorieën.Add(new Categorie("Polariteit"));

         List<Persoon> personen = berichtMng.GetPersonen().ToList();
         personen.Sort((p1, p2) => p1.Naam.CompareTo(p2.Naam));

         return View("GrafiekToevoegen", new GrafiekPersonen() { Grafiek = graf, Personen = personen });
      }
   }
}