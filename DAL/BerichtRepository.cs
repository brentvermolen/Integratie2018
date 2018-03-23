using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;

namespace DAL
{
   public class BerichtRepository : IBerichtRepository
   {
      private Integratie2018Context ctx;

      public BerichtRepository()
      {
         ctx = new Integratie2018Context();
      }

      public IEnumerable<Bericht> LeesBerichten(int aantal, string vanPersoon = "")
      {
         return ctx.AddBerichten(aantal, vanPersoon);
      }

      public Bericht CreateBericht(Bericht bericht)
      {
         ctx.Berichten.Add(bericht);
         ctx.SaveChanges();
         return bericht;
      }

      public Hashtag CreateBerichtHashtag(string berichtID, Hashtag hashtag)
      {
         Bericht bericht = ctx.Berichten.Find(berichtID);
         bericht.Hashtags.Add(hashtag);

         UpdateBericht(bericht);
         return hashtag;
      }

      public Mention CreateBerichtMention(string berichtID, Mention mention)
      {
         Bericht bericht = ctx.Berichten.Find(berichtID);
         bericht.Mentions.Add(mention);

         UpdateBericht(bericht);
         return mention;
      }

      public Url CreateBerichtUrl(string berichtID, Url url)
      {
         Bericht bericht = ctx.Berichten.Find(berichtID);
         bericht.Urls.Add(url);

         UpdateBericht(bericht);
         return url;
      }

      public Woord CreateBerichtWoord(string berichtID, Woord woord)
      {
         Bericht bericht = ctx.Berichten.Find(berichtID);
         bericht.Woorden.Add(woord);

         UpdateBericht(bericht);
         return woord;
      }

      public Hashtag CreateHashtag(Hashtag hashtag)
      {
         ctx.Hashtags.Add(hashtag);
         ctx.SaveChanges();
         return hashtag;
      }

      public Mention CreateMention(Mention mention)
      {
         ctx.Mentions.Add(mention);
         ctx.SaveChanges();
         return mention;
      }

      public Persoon CreatePersoon(Persoon persoon)
      {
         ctx.Personen.Add(persoon);
         ctx.SaveChanges();
         return persoon;
      }

      public Url CreateUrl(Url url)
      {
         ctx.Urls.Add(url);
         ctx.SaveChanges();
         return url;
      }

      public Woord CreateWoord(Woord woord)
      {
         ctx.Woorden.Add(woord);
         ctx.SaveChanges();
         return woord;
      }

      public void DeleteBericht(string berichtID)
      {
         ctx.Berichten.Remove(ReadBericht(berichtID));
         ctx.SaveChanges();
      }

      public void DeleteHashtag(string hashtag)
      {
         ctx.Hashtags.Remove(ReadHashtag(hashtag));
         ctx.SaveChanges();
      }

      public void DeleteMention(string mention)
      {
         ctx.Mentions.Remove(ReadMention(mention));
         ctx.SaveChanges();
      }

      public void DeletePersoon(string persoon)
      {
         ctx.Personen.Remove(ReadPersoon(persoon));
      }

      public void DeleteUrl(string url)
      {
         ctx.Urls.Remove(ReadUrl(url));
         ctx.SaveChanges();
      }

      public void DeleteWoord(string woord)
      {
         ctx.Woorden.Remove(ReadWoord(woord));
         ctx.SaveChanges();
      }

      public Bericht ReadBericht(string berichtID)
      {
         return ctx.Berichten
            .Include("Hashtags")
            .Include("Woorden")
            .Include("Urls")
            .Include("Mentions")
            .Include("Politieker")
            .SingleOrDefault(b => b.ID.Equals(berichtID));
      }

      public IEnumerable<Bericht> ReadBerichten()
      {
         return ctx.Berichten
            .Include("Hashtags")
            .Include("Woorden")
            .Include("Urls")
            .Include("Mentions")
            .Include("Politieker");
      }

      public Hashtag ReadHashtag(string hashtag)
      {
         return ctx.Hashtags.Find(hashtag);
      }

      public IEnumerable<Hashtag> ReadHashtags()
      {
         return ctx.Hashtags.Include("Berichten");
      }

      public IEnumerable<Hashtag> ReadHashtagsVanBericht(string berichtID)
      {
         return ctx.Berichten.Include("Hashtags").Single(b => b.ID.Equals(berichtID)).Hashtags;
      }

      public Mention ReadMention(string mention)
      {
         return ctx.Mentions.Find(mention);
      }

      public IEnumerable<Mention> ReadMentions()
      {
         return ctx.Mentions.Include("Berichten");
      }

      public IEnumerable<Mention> ReadMentionsVanBericht(string berichtID)
      {
         return ctx.Berichten.Include("Mentions").Single(b => b.ID.Equals(berichtID)).Mentions;
      }

      public IEnumerable<Persoon> ReadPersonen()
      {
         return ctx.Personen
            .Include("Berichten");
      }

      public Persoon ReadPersoon(string naam)
      {
         return ctx.Personen
            .Include("Berichten")
            .FirstOrDefault(p => p.Naam.Equals(naam));
      }

      public Url ReadUrl(string url)
      {
         return ctx.Urls.Find(url);
      }

      public IEnumerable<Url> ReadUrls()
      {
         return ctx.Urls.Include("Berichten");
      }

      public IEnumerable<Url> ReadUrlsVanBericht(string berichtID)
      {
         return ctx.Berichten.Include("Urls").Single(b => b.ID.Equals(berichtID)).Urls;
      }

      public Woord ReadWoord(string woord)
      {
         return ctx.Woorden.Find(woord);
      }

      public IEnumerable<Woord> ReadWoorden()
      {
         return ctx.Woorden.Include("Berichten");
      }

      public IEnumerable<Woord> ReadWoordenVanBericht(string berichtID)
      {
         return ctx.Berichten.Include("Woorden").Single(b => b.ID.Equals(berichtID)).Woorden;
      }

      public void UpdateBericht(Bericht bericht)
      {
         ctx.Entry(bericht).State = System.Data.Entity.EntityState.Modified;
         ctx.SaveChanges();
      }
   }
}
