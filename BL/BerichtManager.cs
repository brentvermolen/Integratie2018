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

      public IEnumerable<Bericht> LeesBerichten(int aantal, string vanPersoon = "")
      {
         return repo.LeesBerichten(aantal, vanPersoon);
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

      public void AddPersoon(string berichtID, string persoon)
      {
         Persoon p = GetPersoon(persoon);
         if (p == null)
         {
            p = new Persoon() { Naam = persoon };
            repo.CreatePersoon(p);
         }
      }

      public void AddPersoon(string berichtID, List<string> persoon)
      {
         AddPersoon(berichtID, string.Join(" ", persoon));
      }

      public void AddUrl(string berichtID, string url)
      {
         Url u = repo.ReadUrl(url);
         if (u == null)
         {
            u = new Url() { Tekst = url };
            repo.CreateUrl(u);
         }
         repo.CreateBerichtUrl(berichtID, u);
      }

      public void AddWoord(string berichtID, string woord)
      {
         Woord w = repo.ReadWoord(woord);
         if (w == null)
         {
            w = new Woord() { Tekst = woord };
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

      public Persoon GetPersoon(string persoon)
      {
         return repo.ReadPersoon(persoon);
      }

      public Persoon GetPersoonVanBericht(string berichtID)
      {
         return GetBericht(berichtID).Politieker;
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
