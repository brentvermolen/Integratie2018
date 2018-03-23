using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface IBerichtRepository
   {
      IEnumerable<Bericht> LeesBerichten(int aantal, string vanPersoon = "");

      Bericht CreateBericht(Bericht bericht);
      IEnumerable<Bericht> ReadBerichten();
      Bericht ReadBericht(string berichtID);
      void UpdateBericht(Bericht bericht);
      void DeleteBericht(string berichtID);

      IEnumerable<Woord> ReadWoordenVanBericht(string berichtID);
      IEnumerable<Url> ReadUrlsVanBericht(string berichtID);
      IEnumerable<Mention> ReadMentionsVanBericht(string berichtID);
      IEnumerable<Hashtag> ReadHashtagsVanBericht(string berichtID);

      Woord CreateBerichtWoord(string berichtID, Woord woord);
      Url CreateBerichtUrl(string berichtID, Url url);
      Mention CreateBerichtMention(string berichtID, Mention mention);
      Hashtag CreateBerichtHashtag(string berichtID, Hashtag hashtag);

      Persoon CreatePersoon(Persoon persoon);
      Persoon ReadPersoon(string naam);
      IEnumerable<Persoon> ReadPersonen();
      void DeletePersoon(string persoon);

      Woord CreateWoord(Woord woord);
      IEnumerable<Woord> ReadWoorden();
      Woord ReadWoord(string woord);
      void DeleteWoord(string woord);

      Url CreateUrl(Url url);
      IEnumerable<Url> ReadUrls();
      Url ReadUrl(string url);
      void DeleteUrl(string url);

      Mention CreateMention(Mention mention);
      IEnumerable<Mention> ReadMentions();
      Mention ReadMention(string mention);
      void DeleteMention(string mention);

      Hashtag CreateHashtag(Hashtag hashtag);
      IEnumerable<Hashtag> ReadHashtags();
      Hashtag ReadHashtag(string hashtag);
      void DeleteHashtag(string hashtag);
   }
}
