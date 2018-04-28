using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.ItemKlassen;
using BL.Interfaces;
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
         List<Grafiek> graf = grafiekenMng.GetGrafieken().Where(g => count++ < 3).ToList();

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
         Grafiek graf = new Bar("preview", "PREVIEW", new As() { IsUsed = true, Categorieën = new List<Categorie>() }, new List<Serie>());
         graf.xAs.Categorieën.Add(new Categorie("Categorie1"));
         graf.xAs.Categorieën.Add(new Categorie("Categorie2"));
         graf.xAs.Categorieën.Add(new Categorie("Categorie3"));
         Serie serie = new Serie()
         {
            Naam = "Serie 1"
         };
         Data data = new Data(0);
         Data data2 = new Data(0);
         Data data3 = new Data(0);
         serie.Data.Add(data);
         serie.Data.Add(data2);
         serie.Data.Add(data3);

         graf.Series.Add(serie);

         return View("GrafiekToevoegen", graf);
      }
   }
}