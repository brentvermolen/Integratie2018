using BL;
using BL.Domain;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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

      [Route("~/api/NieuweGrafiek/AantalTweetsVanPersoon/{id}/{aantalDagen}")]
      public IHttpActionResult GetAantalTweetsVanPersoon(string id, string aantalDagen)
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
         int intAantalDagen = -1;
         try
         {
            intAantalDagen = int.Parse(aantalDagen);
         }catch(Exception e)
         {
            intAantalDagen = 30;
         }

         DateTime datumVandaag = DateTime.Today;
         datumVandaag = datumVandaag.AddDays(0 - intAantalDagen);

         List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null && b.Datum >= datumVandaag).ToList();

         var test = berichts.GroupBy(t => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(t.Datum, CalendarWeekRule.FirstDay, DayOfWeek.Monday));
         List<AantalBerichtenPerWeek> lijst = new List<AantalBerichtenPerWeek>();

         int eersteWeek = test.Min(t => t.Key);
         datumVandaag = new DateTime(2018, 1, 1);
         datumVandaag = datumVandaag.AddDays(eersteWeek * 7 - 6);

         while(datumVandaag <= DateTime.Today.AddDays(7))
         {
            lijst.Add(new AantalBerichtenPerWeek() { Week = datumVandaag, Count = 0 });
            datumVandaag = datumVandaag.AddDays(7);
         }

         int i = 0;
         foreach (var key in test)
         {
            int aantal = key.Count();
            int dagen = key.Key * 7 - 6;
            DateTime date = new DateTime(2018, 1, 1);
            date = date.AddDays(dagen);

            AantalBerichtenPerWeek item = lijst[i++];

            if (item.Week == date)
            {
               item.Count = aantal;
            }
         }
         lijst.Sort((m1, m2) => m1.Week.CompareTo(m2.Week));

         AantalBerichtenPerWeekModel model = new AantalBerichtenPerWeekModel()
         {
            Start = lijst.Min(l => l.Week),
            Data = new List<int>()
         };

         for (i = 0; i < lijst.Count; i++)
         {
            model.Data.Add(lijst[i].Count);
         }

         return Ok(model);
      }

      public class AantalBerichtenPerWeekModel
      {
         public DateTime Start { get; set; }
         public List<int> Data { get; set; }
      }

      public class AantalBerichtenPerWeek
      {
         public int Count { get; set; }
         public DateTime Week { get; set; }
      }

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
