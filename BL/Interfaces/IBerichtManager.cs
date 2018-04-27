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

      ICollection<Persoon> GetPersoonVanBericht(string berichtID);

      void AddPersoon(string berichtID, string persoon);
      void AddPersoon(string berichtID, List<string> persoon);
      Persoon GetPersoon(string persoon);

      IEnumerable<Woord> GetBerichtWoorden(string berichtID);
      IEnumerable<Url> GetBerichtUrls(string berichtID);
      IEnumerable<Mention> GetBerichtMentions(string berichtID);
      IEnumerable<Hashtag> GetBerichtHashtags(string berichtID);

      IEnumerable<Woord> GetWoorden();
      IEnumerable<Url> GetUrls();
      IEnumerable<Mention> GetMentions();
      IEnumerable<Hashtag> GetHashtags();

      void AddWoord(string berichtID, string woord);
      void AddUrl(string berichtID, string url);
      void AddMention(string berichtID, string mention);
      void AddHashtag(string berichtID, string hashtag);
   }
}
