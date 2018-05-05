using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IBerichtManager
   {
      IEnumerable<Bericht> GetBerichten();
      IEnumerable<Bericht> GetBerichten(System.Linq.Expressions.Expression<Func<Bericht, bool>> predicate);
      Bericht GetBericht(string id);
      Bericht AddBericht(Bericht bericht);
      void RemoveBericht(string berichtID);

      IEnumerable<Persoon> GetPersonen();
      IEnumerable<Persoon> GetPersonen(System.Linq.Expressions.Expression<Func<Persoon, bool>> predicate);

      ICollection<Persoon> GetPersoonVanBericht(string berichtID);

      void AddPersoon(string berichtID, int persoonID);
      Persoon GetPersoon(int id);

      IEnumerable<Woord> GetBerichtWoorden(string berichtID);
      IEnumerable<Url> GetBerichtUrls(string berichtID);
      IEnumerable<Mention> GetBerichtMentions(string berichtID);
      IEnumerable<Hashtag> GetBerichtHashtags(string berichtID);

      IEnumerable<Woord> GetWoorden();
      IEnumerable<Woord> GetWoorden(System.Linq.Expressions.Expression<Func<Woord, bool>> predicate);
      IEnumerable<Url> GetUrls();
      IEnumerable<Url> GetUrls(System.Linq.Expressions.Expression<Func<Url, bool>> predicate);
      IEnumerable<Mention> GetMentions();
      IEnumerable<Mention> GetMentions(System.Linq.Expressions.Expression<Func<Mention, bool>> predicate);
      IEnumerable<Hashtag> GetHashtags();
      IEnumerable<Hashtag> GetHashtags(System.Linq.Expressions.Expression<Func<Hashtag, bool>> predicate);

      void AddWoord(string berichtID, string woord);
      void AddUrl(string berichtID, string url);
      void AddMention(string berichtID, string mention);
      void AddHashtag(string berichtID, string hashtag);
   }
}
