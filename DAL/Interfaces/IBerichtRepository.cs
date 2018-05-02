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
      Bericht CreateBericht(Bericht bericht);
      IEnumerable<Bericht> ReadBerichten();
      IEnumerable<Bericht> ReadBerichten(System.Linq.Expressions.Expression<Func<Bericht, bool>> predicate);
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
      Persoon ReadPersoon(int id);
      IEnumerable<Persoon> ReadPersonen();
      IEnumerable<Persoon> ReadPersonen(System.Linq.Expressions.Expression<Func<Persoon, bool>> predicate);
      void DeletePersoon(int id);

      Woord CreateWoord(Woord woord);
      IEnumerable<Woord> ReadWoorden();
      IEnumerable<Woord> ReadWoorden(System.Linq.Expressions.Expression<Func<Woord, bool>> predicate);
      Woord ReadWoord(string woord);
      void DeleteWoord(string woord);

      Url CreateUrl(Url url);
      IEnumerable<Url> ReadUrls();
      IEnumerable<Url> ReadUrls(System.Linq.Expressions.Expression<Func<Url, bool>> predicate);
      Url ReadUrl(string url);
      void DeleteUrl(string url);

      Mention CreateMention(Mention mention);
      IEnumerable<Mention> ReadMentions();
      IEnumerable<Mention> ReadMentions(System.Linq.Expressions.Expression<Func<Mention, bool>> predicate);
      Mention ReadMention(string mention);
      void DeleteMention(string mention);

      Hashtag CreateHashtag(Hashtag hashtag);
      IEnumerable<Hashtag> ReadHashtags();
      IEnumerable<Hashtag> ReadHashtags(System.Linq.Expressions.Expression<Func<Hashtag, bool>> predicate);
      Hashtag ReadHashtag(string hashtag);
      void DeleteHashtag(string hashtag);
   }
}
