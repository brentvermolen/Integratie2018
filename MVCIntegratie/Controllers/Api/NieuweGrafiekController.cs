using BL;
using BL.Domain;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVCIntegratie.Controllers.Api
{
    public class NieuweGrafiekController : ApiController
   {
      private IBerichtManager berichtMng = new BerichtManager();
      private IAlertManager alertMng = new AlertManager();
      private IGebruikerManager gebruikerMng = new GebruikerManager();
      private GrafiekenManager grafiekenMng = new GrafiekenManager();

      [Route("~/api/NieuweGrafiek/SentimentVanPersoon/{id}")]
      public IHttpActionResult GetSentimentVanPersoon(string id)
      {
         int intID = -1;
         try
         {
            intID = int.Parse(id);
         }
         catch
         {
            return NotFound();
         }         
         List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList();

         SentimentModel model = new SentimentModel()
         {
            Naam = berichtMng.GetPersoon(intID).Naam,
            Objectiviteit = berichts.Average(b => b.Objectiviteit),
            Polariteit = berichts.Average(b => b.Polariteit)
         };

         return Ok(model);
      }

      [Route("~/api/NieuweGrafiek/PostGrafiek")]
      public IHttpActionResult Post([FromBody]string data)
      {
         GrafiekJson json = JsonConvert.DeserializeObject<GrafiekJson>(data);

         List<Categorie> categories = new List<Categorie>();
         List<Serie> series = new List<Serie>();

         foreach (string categorie in json.categories)
         {
            categories.Add(new Categorie(categorie));
         }
         foreach(string serie in json.series)
         {
            int intID = -1;
            try
            {
               intID = int.Parse(serie);
            }
            catch
            {
               return NotFound();
            }
            List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList();

            SentimentModel model = new SentimentModel()
            {
               Naam = berichtMng.GetPersoon(intID).Naam,
               Objectiviteit = berichts.Average(b => b.Objectiviteit),
               Polariteit = berichts.Average(b => b.Polariteit)
            };

            Serie s = new Serie()
            {
               Naam = model.Naam
            };
            Data d1 = new Data(model.Objectiviteit);
            Data d2 = new Data(model.Polariteit);
            s.Data.Add(d1); s.Data.Add(d2);

            series.Add(s);
         }

         Grafiek grafiek = new Bar(
            grafiekenMng.NewGrafiek().ID,
            json.title,
            new As() { Categorieën = categories},
            series
            );

         grafiekenMng.AddGrafiek(grafiek);

         return Ok();
      }

      public class GrafiekJson
      {
         public string title { get; set; }
         public List<string> categories { get; set; }
         public bool credits { get; set; }
         public List<string> series { get; set; }
      }

      public class SentimentModel
      {
         public string Naam { get; set; }
         public double Objectiviteit { get; set; }
         public double Polariteit { get; set; }
      }
   }
}
