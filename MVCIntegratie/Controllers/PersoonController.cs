using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekTypes;
using MVCIntegratie.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCIntegratie.Controllers
{
    public partial class PersoonController : Controller
    {
        private BerichtManager mng = new BerichtManager();
        private GrafiekenManager GrafiekenMng = new GrafiekenManager();

        public virtual ActionResult Index(int id)
        {
            Persoon persoon = mng.GetPersoon(id);
            Grafiek grafiek = new Lijn();
            List<Woord> keywoorden = new List<Woord>();
            List<Bericht> berichten = new List<Bericht>();
            List<Url> urls = new List<Url>();

            grafiek.Titel = "Aantal Tweets - Per Dag - " + persoon.Naam;
            grafiek.ContentType = "politieker";
            grafiek.TitelXAs = "dag";
            grafiek.AantalSeries = 4;
            grafiek.Personen = new List<Persoon>();
            grafiek.Personen.Add(persoon);
            grafiek.TitelYAs = "Aantal Tweets";

            grafiek = GrafiekenMng.CreateGrafiek(grafiek);


            berichten.AddRange(persoon.Berichten);

            foreach (Bericht b in berichten)
            {
                foreach (Woord woord in b.Woorden)
                {
                    if (keywoorden.Contains(woord))
                    {
                        continue;
                    }
                    else
                    {
                        keywoorden.Add(woord);
                    }

                }

                foreach (Url url in b.Urls)
                {
                    if (urls.Contains(url))
                    {
                        continue;
                    }
                    else
                    {
                        urls.Add(url);
                    }

                }



            }

            PersoonModel model = new PersoonModel()
            {
                Persoon = persoon,
                Grafiek = grafiek,
                Keywoorden = keywoorden,
                Urls = urls

            };
            return View(model);
        }
    }
}