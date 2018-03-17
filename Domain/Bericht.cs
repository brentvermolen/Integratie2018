using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Bericht
   {
      [Key]
      [JsonProperty("id")]
      public string ID { get; set; }
      [JsonProperty("user_id")]
      public string User_ID { get; set; }
      [JsonProperty("date")]
      public DateTime Datum { get; set; }
      [JsonProperty("geo")]
      public string Geo { get; set; }
      [JsonProperty("retweet")]
      public bool Retweet { get; set; }
      [JsonProperty("source")]
      public string Bron { get; set; }

      [JsonProperty("sentiment")]
      public List<double> Sentiment { get; set; }
      public double Polariteit { get; set; }
      public double Objectiviteit { get; set; }
      [JsonProperty("politician")]
      public List<string> PolitiekerJson { get; set; }
      public string Politieker { get; set; }
      [JsonProperty("words")]
      public List<string> WoordenJson { get; set; }
      public string Woorden { get; set; }
      [JsonProperty("urls")]
      public List<string> UrlsJson { get; set; }
      public string Urls { get; set; }
      [JsonProperty("hashtags")]
      public List<string> HashtagsJson { get; set; }
      public string Hashtags { get; set; }
      [JsonProperty("mentions")]
      public List<string> MentionsJson { get; set; }
      public string Mentions { get; set; }

      public override bool Equals(object obj)
      {
         if (obj.GetType() != GetType())
         {
            return false;
         }

         Bericht bericht = (Bericht)obj;
         if (bericht.ID == ID)
         {
            return true;
         }

         return false;
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override string ToString()
      {
         return ID;
      }
   }
}
