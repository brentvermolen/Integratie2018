using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.BerichtKlassen
{
   public class Hashtag
   {
      public Hashtag()
      {
         Berichten = new List<Bericht>();
      }
      public Hashtag(string hashtag)
      {
         Berichten = new List<Bericht>();
         Tekst = hashtag;
      }

      [Key]
      [JsonProperty]
      public string Tekst { get; set; }

      public ICollection<Bericht> Berichten { get; set; }

      public override string ToString()
      {
         return Tekst;
      }
   }
}
