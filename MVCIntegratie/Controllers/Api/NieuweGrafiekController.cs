using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.ItemKlassen;
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

      [Route("~/api/NieuweGrafiek/AantalTweetsVanPersoonPerWeek/{id}/{aantalWeken}")]
      public IHttpActionResult GetAantalTweetsVanPersoonPerWeek(string id, string aantalWeken)
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
         int intAantalWeken = -1;
         try
         {
            intAantalWeken = int.Parse(aantalWeken);
         }catch(Exception e)
         {
            intAantalWeken = 5;
         }

         return Ok(GetAantalBerichtenPerWeekModel(intAantalWeken, intID));
      }

      [Route("~/api/NieuweGrafiek/AantalXVanPersoon/{type}/{id}")]
      public IHttpActionResult GetAantalXVanPersoon(string type, string id)
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

         switch (type)
         {
            case "tweets":
               return Ok(berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count);
            case "mentions":
               return Ok(berichtMng.GetMentions().Where(m => m.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null) != null).ToList().Count);
            case "hashtags":
               return Ok(berichtMng.GetHashtags().Where(h => h.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null) != null).ToList().Count);
         }

         return NotFound();
      }

      private AantalBerichtenPerWeekModel GetAantalBerichtenPerWeekModel(int intAantalWeken, int intID)
      {
         int dezeWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

         int eersteWeek = dezeWeek - intAantalWeken;
         DateTime datumVandaag = new DateTime(2018, 1, 1).AddDays(dezeWeek * 7 - 7);
         datumVandaag = datumVandaag.AddDays(0 - (intAantalWeken * 7 - 7));

         List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null && b.Datum >= datumVandaag).ToList();

         var test = berichts.GroupBy(t => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(t.Datum, CalendarWeekRule.FirstDay, DayOfWeek.Monday));
         List<AantalBerichtenPerWeek> lijst = new List<AantalBerichtenPerWeek>();

         while (eersteWeek++ < dezeWeek)
         {
            lijst.Add(new AantalBerichtenPerWeek() { Week = datumVandaag, Count = 0 });
            datumVandaag = datumVandaag.AddDays(7);
         }

         int i = 0;

         DateTime date = new DateTime(2018, 1, 1);
         int minsteWeek = test.Min(w => w.Key);
         date = date.AddDays(minsteWeek * 7 - 7);

         test = test.OrderBy(t => t.Key);

         foreach (var key in test)
         {
            int aantal = key.Count();

            AantalBerichtenPerWeek item = lijst[i++];

            while (item.Week != date)
            {
               item = lijst[i++];
            }

            if (item.Week == date)
            {
               item.Count = aantal;
               date = date.AddDays(7);
            }
         }
         lijst.Sort((m1, m2) => m1.Week.CompareTo(m2.Week));

         DateTime vroegste = lijst.Min(l => l.Week);

         AantalBerichtenPerWeekModel model = new AantalBerichtenPerWeekModel()
         {
            ID = intID,
            Naam = berichtMng.GetPersoon(intID).Naam,
            StartJaart = vroegste.Year,
            StartMaand = vroegste.Month,
            StartDag = vroegste.Day,
            Data = new List<int>()
         };

         for (i = 0; i < lijst.Count; i++)
         {
            model.Data.Add(lijst[i].Count);
         }

         return model;
      }

      public class AantalBerichtenPerWeekModel
      {
         public int ID { get; set; }
         public string Naam { get; set; }
         public int StartJaart { get; set; }
         public int StartMaand { get; set; }
         public int StartDag { get; set; }
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

      [Route("~/api/NieuweGrafiek/PieDataPersoon/{id}/{type}/{top}")]
      public IHttpActionResult GetPieDataPersoon(string id, string type, string top)
      {
         int intTop;
         try
         {
            intTop = int.Parse(top.Replace("Top", ""));
         }catch(Exception e)
         {
            return NotFound();
         }

         int intID;
         try
         {
            intID = int.Parse(id);
         }catch(Exception e)
         {
            return NotFound();  
         }

         PieDataPersoonModel model = new PieDataPersoonModel()
         {
            Persoon = berichtMng.GetPersoon(intID).Naam,
            Series = new List<string>(),
            Waarden = new List<double>()
         };

         //List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList();
         int intTeller;

         switch (type)
         {
            case "Verhalen":
               List<Url> urls = berichtMng.GetUrls().Where(w => w.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null) != null).ToList();
               urls.Sort((w1, w2) => w2.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count.CompareTo(w1.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count));

               intTeller = 0;
               while (model.Series.Count < intTop)
               {
                  Url url = urls[intTeller];

                  model.Series.Add(url.Tekst);
                  model.Waarden.Add(url.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count);

                  intTeller++;
               }

               return Ok(model);
            case "Woorden":
               List<Woord> woorden = berichtMng.GetWoorden().Where(w => w.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null) != null).ToList();
               woorden.Sort((w1, w2) => w2.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count.CompareTo(w1.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count));

               intTeller = 0;
               while(model.Series.Count < intTop)
               {
                  Woord woord = woorden[intTeller];
                  if (!model.Persoon.ToLower().Contains(woord.Tekst.ToLower()))
                  {
                     model.Series.Add(woord.Tekst);
                     model.Waarden.Add(woord.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count);
                  }
                  intTeller++;
               }
               
               return Ok(model);
            case "Themas":
               return NotFound();
            case "Gemeente":
               //var berichten = berichtMng.GetBerichten().GroupBy(b => b.Geo);
               break;
            case "Geslacht":
               var geslacht = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Geslacht);

               geslacht = geslacht.OrderByDescending(p => p.Count());

               foreach (var group in geslacht)
               {
                  if (group.Key.Equals("f"))
                  {
                     model.Series.Add("Vrouw");
                  }
                  else
                  {
                     model.Series.Add("Man");
                  }
                  model.Waarden.Add(group.Count());
               }

               return Ok(model);
            case "Leeftijd":
               var leeftijd = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Leeftijd);

               leeftijd = leeftijd.OrderByDescending(p => p.Count());

               foreach (var group in leeftijd)
               {
                  if (group.Key.Equals(""))
                  {
                     model.Series.Add("Andere");
                  }
                  else
                  {
                     model.Series.Add(group.Key);
                  }
                  model.Waarden.Add(group.Count());
               }

               return Ok(model);
            case "Opleiding":
               var opleiding = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Scholing);

               opleiding = opleiding.OrderByDescending(p => p.Count());

               foreach (var group in opleiding)
               {
                  if (group.Key.Equals(""))
                  {
                     model.Series.Add("Andere");
                  }
                  else
                  {
                     model.Series.Add(group.Key);
                  }
                  model.Waarden.Add(group.Count());
               }

               return Ok(model);
            case "Taal":
               var taal = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Taal);

               taal = taal.OrderByDescending(p => p.Count());

               foreach (var group in taal)
               {
                  if (group.Key.Equals(""))
                  {
                     model.Series.Add("Andere");
                  }
                  else
                  {
                     model.Series.Add(group.Key);
                  }
                  model.Waarden.Add(group.Count());
               }

               return Ok(model);
            case "Persoonlijkheid":
               var persoonlijkheid = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).GroupBy(b => b.Profiel.Persoonlijkheid);

               persoonlijkheid = persoonlijkheid.OrderByDescending(p => p.Count());

               foreach (var group in persoonlijkheid)
               {
                  if (group.Key.Equals(""))
                  {
                     model.Series.Add("Andere");
                  }
                  else
                  {
                     model.Series.Add(group.Key);
                  }
                  model.Waarden.Add(group.Count());
               }
               
               return Ok(model);
            case "Trend":
               return NotFound();
         }

         return NotFound();
      }

      public class PieDataPersoonModel
      {
         public string Persoon { get; set; }
         public List<string> Series { get; set; }
         public List<double> Waarden { get; set; }
      }

      [Route("~/api/NieuweGrafiek/PostGrafiek")]
      public IHttpActionResult Post([FromBody]string data)
      {
         GrafJson json = JsonConvert.DeserializeObject<GrafJson>(data);

         switch (json.type)
         {
            case "line":
               LineJson line = JsonConvert.DeserializeObject<LineJson>(data);
               line.ToString();
               List<Serie> series = new List<Serie>();

               Grafiek grafiek = new Lijn(grafiekenMng.NewGrafiek().ID,
                  line.title,
                  new As() { Titel = "Aantal Tweets", IsUsed = true },
                  series);

               grafiek.PlotOptions.PointStart = line.pointStart.ToString();

               foreach(PersoonJson persoon in line.series)
               {
                  AantalBerichtenPerWeekModel model = GetAantalBerichtenPerWeekModel(line.aantalWeken, int.Parse(persoon.id));
                  Serie serie = new Serie();
                  serie.Naam = persoon.naam;

                  foreach(int d in model.Data)
                  {
                     Data dat = new Data(d);
                     serie.Data.Add(dat);
                  }

                  grafiek.Series.Add(serie);
               }

               grafiekenMng.AddGrafiek(grafiek);
               break;
            case "bar":
               BarJson bar = JsonConvert.DeserializeObject<BarJson>(data);
               bar.ToString();

               As xAs = new As()
               {
                  IsUsed = true
               };

               As yAs = new As()
               {
                  IsUsed = true,
                  Titel = "Aantal Tweets"
               };

               List<Categorie> categories = new List<Categorie>();

               foreach(string categorie in bar.categories)
               {
                  categories.Add(new Categorie(categorie));
               }

               xAs.Categorieen = categories;

               List<Serie> series2 = new List<Serie>();

               foreach (PersoonJson persoon in bar.series)
               {
                  int id = int.Parse(persoon.id);
                  int aantal = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == id) != null).ToList().Count;
                  Serie serie = new Serie();
                  serie.Naam = berichtMng.GetPersoon(id).Naam;

                  serie.Data.Add(new Data(aantal));
                  series2.Add(serie);
               }

               Grafiek grafiek2 = new Bar(grafiekenMng.NewGrafiek().ID,
                  bar.title,
                  xAs,
                  series2
                  );
               grafiek2.yAs = yAs;

               grafiekenMng.AddGrafiek(grafiek2);
               break;
            case "pie":
               PieJson pie = JsonConvert.DeserializeObject<PieJson>(data);
               pie.ToString();

               Serie serie2 = new Serie();
               serie2.Naam = pie.serieNaam;
               
               for(int i = 0; i < pie.series.Count; i++)
               {
                  Data data2 = new Data()
                  {
                     Naam = pie.series[i].naam,
                     Value = pie.waarden[i]
                  };
                  serie2.Data.Add(data2);
               }

               Grafiek grafiek3 = new Pie(grafiekenMng.NewGrafiek().ID,
                  pie.title,
                  serie2);

               grafiekenMng.AddGrafiek(grafiek3);
               break;
         }
         

         return Ok();
      }

      public class PersoonJson
      {
         public string id { get; set; }
         public string naam { get; set; }
         public bool loaded { get; set; }
      }

      public class GrafJson
      {
         public string type { get; set; }
      }

      public class BarJson
      {
         public string title { get; set; }
         public List<string> categories { get; set; }
         public List<PersoonJson> series { get; set; }
      }

      public class LineJson
      {
         public string title { get; set; }
         public double pointStart { get; set; }
         public string content { get; set; }
         public List<PersoonJson> series { get; set; }
         public int aantalWeken { get; set; }
      }

      public class PieJson
      {
         public string title { get; set; }
         public string serieNaam { get; set; }
         public List<PersoonJson> series { get; set; }
         public List<double> waarden { get; set; }
      }

      public class SentimentModel
      {
         public string Naam { get; set; }
         public double Objectiviteit { get; set; }
         public double Polariteit { get; set; }
      }
   }
}
