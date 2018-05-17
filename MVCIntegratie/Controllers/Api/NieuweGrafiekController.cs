using BL;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.ItemKlassen;
using Microsoft.AspNet.Identity;
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
      private BerichtManager berichtMng = new BerichtManager();
      private AlertManager alertMng = new AlertManager();
      private GebruikerManager gebruikerMng = new GebruikerManager();
      private GrafiekenManager grafiekenMng = new GrafiekenManager();

      [Route("~/api/NieuweGrafiek/Personen")]
      public IHttpActionResult GetPersonen()
      {
         List<Persoon> personen = berichtMng.GetPersonen().ToList();
         personen.ForEach((p) => { p.Berichten = null; p.Grafieken = null; });
         personen.Sort((p1, p2) => p1.Naam.CompareTo(p2.Naam));

         return Ok(personen);
      }

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
         }
         catch (Exception e)
         {
            intAantalWeken = 5;
         }

         return Ok(grafiekenMng.GetAantalBerichtenPerWeekModel(intAantalWeken, intID));
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

         AantalXPerWeekModel model = new AantalXPerWeekModel()
         {
            ID = intID,
            Naam = grafiekenMng.GetPersoon(intID).Naam
         };

         switch (type)
         {
            case "tweets":
               model.Data = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList().Count;
               return Ok(model);
            case "mentions":
               model.Data = berichtMng.GetMentions().Where(m => m.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null) != null).ToList().Count;
               return Ok(model);
            case "hashtags":
               model.Data = berichtMng.GetHashtags().Where(h => h.Berichten.Where(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null) != null).ToList().Count;
               return Ok(model);
         }

         return NotFound();
      }

      public class AantalXPerWeekModel
      {
         public int ID { get; set; }
         public string Naam { get; set; }
         public int Data { get; set; }
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
         }
         catch (Exception e)
         {
            return NotFound();
         }

         int intID;
         try
         {
            intID = int.Parse(id);
         }
         catch (Exception e)
         {
            return NotFound();
         }

         Grafiek grafiek = new Pie()
         {
            AantalSeries = intTop,
            Personen = new List<Persoon>(),
            ContentType = type,
         };
         grafiek.Personen.Add(grafiekenMng.GetPersoon(intID));
         grafiekenMng.CreateGrafiek(grafiek);

         PieDataPersoonModel model = new PieDataPersoonModel()
         {
            Persoon = grafiek.Personen[0].Naam,
            Series = new List<string>(),
            Waarden = new List<double>()
         };

         if (grafiek.Series.Count <= 0)
         {
            return NotFound();
         }

         foreach (Data data in grafiek.Series[0].Data)
         {
            model.Series.Add(data.Naam);
            model.Waarden.Add(data.Value);
         }

         if (grafiek.Series[0].Data.Count > 0)
         {
            return Ok(model);
         }

         //List<Bericht> berichts = berichtMng.GetBerichten(b => b.Personen.FirstOrDefault(p => p.ID == intID) != null).ToList();
         /*int intTeller;

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
               while (model.Series.Count < intTop)
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
         }*/

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
         string gewijzigd = json.gewijzigd;
         int id = grafiekenMng.NewGrafiek().ID;
         if (gewijzigd.Equals("true"))
         {
            id = int.Parse(json.graf);
         }

         int gebruiker = int.Parse(User.Identity.GetUserId());

         switch (json.type)
         {
            case "line":
               LineJson line = JsonConvert.DeserializeObject<LineJson>(data);
               line.ToString();

               Grafiek grafiek = new Lijn();

               try
               {
                  grafiek.Order = grafiekenMng.GetGrafieken().FirstOrDefault(g => g.ID == id).Order;
               }
               catch(Exception e) { }
               grafiek.Titel = line.title;
               grafiek.PointStart = line.pointStart;
               grafiek.ContentType = line.content;
               grafiek.AantalSeries = line.aantalWeken;
               grafiek.Personen = new List<Persoon>();
               grafiek.TitelYAs = "Aantal Tweets";
               grafiek.GebruikerId = gebruiker;

               foreach (PersoonJson persoon in line.series)
               {
                  Persoon p = grafiekenMng.GetPersoon(int.Parse(persoon.id));
                  grafiek.Personen.Add(p);
               }
               /*List<Serie> series = new List<Serie>();

               Grafiek grafiek = new Lijn(grafiekenMng.NewGrafiek().ID,
                  line.title,
                  new As() { Titel = "Aantal Tweets", IsUsed = true },
                  series);
               grafiek.GebruikerId = gebruiker;
               grafiek.PlotOptions.PointStart = line.pointStart.ToString();

               foreach (PersoonJson persoon in line.series)
               {
                  AantalBerichtenPerWeekModel model = GetAantalBerichtenPerWeekModel(line.aantalWeken, int.Parse(persoon.id));
                  Serie serie = new Serie();
                  serie.Naam = persoon.naam;

                  foreach (int d in model.Data)
                  {
                     Data dat = new Data(d);
                     serie.Data.Add(dat);
                  }

                  grafiek.Series.Add(serie);
               }*/

               if (gewijzigd.Equals("true"))
               {
                  grafiekenMng.RemoveGrafiek(id);
               }

               grafiekenMng.AddGrafiek(grafiek);
               break;
            case "bar":
               BarJson bar = JsonConvert.DeserializeObject<BarJson>(data);
               bar.ToString();

               Grafiek grafiek2 = new Bar();
               try
               {
                  grafiek2.Order = grafiekenMng.GetGrafieken().FirstOrDefault(g => g.ID == id).Order;
               }
               catch(Exception e) { }
               grafiek2.Titel = bar.title;
               grafiek2.TitelYAs = "Aantal Tweets";
               grafiek2.TitelXAs = "Aantal Tweets";

               foreach (string categorie in bar.categories)
               {
                  grafiek2.Categorieen.Add(new Categorie(categorie));
               }

               foreach (PersoonJson persoon in bar.series)
               {
                  Persoon p = grafiekenMng.GetPersoon(int.Parse(persoon.id));
                  grafiek2.Personen.Add(p);
               }
               grafiek2.GebruikerId = gebruiker;

               /*As xAs = new As()
               {
                  IsUsed = true
               };

               As yAs = new As()
               {
                  IsUsed = true,
                  Titel = "Aantal Tweets"
               };

               List<Categorie> categories = new List<Categorie>();

               foreach (string categorie in bar.categories)
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
               2
               Grafiek grafiek2 = new Bar(grafiekenMng.NewGrafiek().ID,
                  bar.title,
                  xAs,
                  series2
                  );
               grafiek2.yAs = yAs;
               grafiek2.GebruikerId = gebruiker;*/

               if (gewijzigd.Equals("true"))
               {
                  grafiekenMng.RemoveGrafiek(id);
               }

               grafiekenMng.AddGrafiek(grafiek2);
               break;
            case "pie":
               PieJson pie = JsonConvert.DeserializeObject<PieJson>(data);
               pie.ToString();

               Grafiek grafiek3 = new Pie();
               try
               {
                  grafiek3.Order = grafiekenMng.GetGrafieken().FirstOrDefault(g => g.ID == id).Order;
               }
               catch(Exception e) { }
               grafiek3.Titel = pie.title;
               grafiek3.TitelXAs = pie.serieNaam;
               grafiek3.ContentType = pie.content;
               grafiek3.GebruikerId = gebruiker;
               grafiek3.Personen.Add(grafiekenMng.GetPersoon(int.Parse(pie.persoon)));
               /*Serie serie2 = new Serie();
               serie2.Naam = pie.serieNaam;

               for (int i = 0; i < pie.series.Count; i++)
               {
                  Data data2 = new Data()
                  {
                     Naam = pie.series[i],
                     Value = pie.waarden[i]
                  };
                  serie2.Data.Add(data2);
               }

               Grafiek grafiek3 = new Pie(grafiekenMng.NewGrafiek().ID,
                  pie.title,
                  serie2);
               grafiek3.GebruikerId = gebruiker;*/

               if (gewijzigd.Equals("true"))
               {
                  grafiekenMng.RemoveGrafiek(id);
               }
               
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
         public string gewijzigd { get; set; }
         public string graf { get; set; }
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
         /*public List<string> series { get; set; }
         public List<double> waarden { get; set; }*/
         public string content { get; set; }
         public string persoon { get; set; }
      }

      public class SentimentModel
      {
         public string Naam { get; set; }
         public double Objectiviteit { get; set; }
         public double Polariteit { get; set; }
      }

      [Route("~/api/NieuweGrafiek/WijzigVolgorde")]
      public IHttpActionResult PostWijzigVolgorde([FromBody] string data)
      {
         VolgordeJson volgorde = JsonConvert.DeserializeObject<VolgordeJson>(data);
         int user = int.Parse(User.Identity.GetUserId());

         List<Grafiek> grafs = grafiekenMng.GetGrafieken().Where(g => g.GebruikerId == user).ToList();

         for (int i = 0; i < volgorde.grafiek.Count; i++)
         {
            int grafId = int.Parse(volgorde.grafiek[i]);
            int v = int.Parse(volgorde.volgorde[i]);

            Grafiek g = grafs.FirstOrDefault(gr => gr.ID == grafId);
            g.Order = v;

            grafiekenMng.ChangeGrafiek(g);
         }

         return Ok();
      }

      public class VolgordeJson
      {
         public List<string> grafiek { get; set; }
         public List<string> volgorde { get; set; }
      }
   }
}
