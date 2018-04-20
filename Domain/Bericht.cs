using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BL.Domain
{
   public class Bericht
   {
      public Bericht()
      {
         Woorden = new List<Woord>();
         Urls = new List<Url>();
         Mentions = new List<Mention>();
         Hashtags = new List<Hashtag>();
      }

      [Key]
      [JsonProperty("id")]
      public string ID { get; set; }
      [JsonProperty("profile")]
      public Profiel Profiel { get; set; }
      [JsonProperty("user_id")]
      public string User_ID { get; set; }
      [JsonProperty("date")]
      public DateTime Datum { get; set; }
      [JsonProperty("geo")]
      public IList<double> Geo { get; set; }
      public double Longtitude { get; set; }
      public double Latitude { get; set; }
      [JsonProperty("retweet")]
      public bool Retweet { get; set; }
      [JsonProperty("source")]
      public string Bron { get; set; }

      [JsonProperty("sentiment")]
      public IList<double> Sentiment { get; set; }
      public double Polariteit { get; set; }
      public double Objectiviteit { get; set; }
      [JsonProperty("persons")]
      public ICollection<string> PersonenJson { get; set; }
      public ICollection<Persoon> Personen { get; set; }
      [JsonProperty("words")]
      public ICollection<string> WoordenJson { get; set; }
      public ICollection<Woord> Woorden { get; set; }
      [JsonProperty("urls")]
      public ICollection<string> UrlsJson { get; set; }
      public ICollection<Url> Urls { get; set; }
      public ICollection<string> HashtagsJson { get; set; }
      [JsonProperty("hashtags")]
      public ICollection<Hashtag> Hashtags { get; set; }
      [JsonProperty("mentions")]
      public ICollection<string> MentionsJson { get; set; }
      public ICollection<Mention> Mentions { get; set; }
      [JsonProperty("themes")]
      public ICollection<string> ThemesJson { get; set; }
      public ICollection<Mention> Themes { get; set; }

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
