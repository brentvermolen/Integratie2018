using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using DAL;

namespace BL
{
   public class BerichtManager : IBerichtManager
   {
      private readonly IBerichtRepository repo;

      public BerichtManager()
      {
         repo = new BerichtRepository();
      }

      public Bericht AddBericht(Bericht bericht)
      {
         return repo.CreateBericht(bericht);
      }

      public void AddHashtag(string berichtID, string hashtag)
      {
         Hashtag h = repo.ReadHashtag(hashtag);
         if (h == null)
         {
            h = new Hashtag() { Tekst = hashtag };
            repo.CreateHashtag(h);
         }
         repo.CreateBerichtHashtag(berichtID, h);
      }

      public void AddMention(string berichtID, string mention)
      {
         Mention m = repo.ReadMention(mention);
         if (m == null)
         {
            m = new Mention() { Tekst = mention };
            repo.CreateMention(m);
         }
         repo.CreateBerichtMention(berichtID, m);
      }

      public void AddPersoon(string berichtID, int persoonID)
      {
         Persoon p = GetPersoon(persoonID);
         if (p == null)
         {
            p = new Persoon() { ID = persoonID };
            repo.CreatePersoon(p);
         }
      }

      public void AddUrl(string berichtID, string url)
      {
         Url u = repo.ReadUrl(url);
         if (u == null)
         {
            u = new Url() { ID = repo.ReadUrls().Count(), Tekst = url };
            repo.CreateUrl(u);
         }
         repo.CreateBerichtUrl(berichtID, u);
      }

      public void AddWoord(string berichtID, string woord)
      {
         Woord w = repo.ReadWoord(woord);
         if (w == null)
         {
            w = new Woord() { ID = repo.ReadWoorden().Count(), Tekst = woord };
            repo.CreateWoord(w);
         }
         repo.CreateBerichtWoord(berichtID, w);
      }

      public Bericht GetBericht(string id)
      {
         return repo.ReadBericht(id);
      }

      public IEnumerable<Bericht> GetBerichten()
      {
         return repo.ReadBerichten();
      }

      public IEnumerable<Bericht> GetBerichten(System.Linq.Expressions.Expression<Func<Bericht, bool>> predicate)
      {
         return repo.ReadBerichten(predicate);
      }

      public IEnumerable<Hashtag> GetBerichtHashtags(string berichtID)
      {
         return repo.ReadHashtagsVanBericht(berichtID);
      }

      public IEnumerable<Mention> GetBerichtMentions(string berichtID)
      {
         return repo.ReadMentionsVanBericht(berichtID);
      }

      public IEnumerable<Url> GetBerichtUrls(string berichtID)
      {
         return repo.ReadUrlsVanBericht(berichtID);
      }

      public IEnumerable<Woord> GetBerichtWoorden(string berichtID)
      {
         return repo.ReadWoordenVanBericht(berichtID);
      }

      public IEnumerable<Hashtag> GetHashtags()
      {
         return repo.ReadHashtags();
      }

      public IEnumerable<Mention> GetMentions()
      {
         return repo.ReadMentions();
      }

      public IEnumerable<Persoon> GetPersonen()
      {
         return repo.ReadPersonen();
      }

      public Persoon GetPersoon(int id)
      {
         return repo.ReadPersoon(id);
      }

      public ICollection<Persoon> GetPersoonVanBericht(string berichtID)
      {
         return GetBericht(berichtID).Personen;
      }

      public IEnumerable<Url> GetUrls()
      {
         return repo.ReadUrls();
      }

      public IEnumerable<Woord> GetWoorden()
      {
         return repo.ReadWoorden();
      }

      public void RemoveBericht(string berichtID)
      {
         repo.DeleteBericht(berichtID);
      }
   }
}
