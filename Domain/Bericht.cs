using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using BL.Domain.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
      [NotMapped]
      [JsonProperty("geo", ItemConverterType = typeof(DoubleConvert))]
      public IList<double> Geo { get; set; }

      [Column("Longtitude")]
      public double Longitude
      {
         get
         {
            return Geo[0];
         }
         set
         {
            Geo[0] = value;
         }
      }

      [Column("Latitude")]
      public double Latitude
      {
         get
         {
            return Geo[1];
         }
         set
         {
            Geo[1] = value;
         }
      }
      [JsonProperty("retweet")]
      public bool Retweet { get; set; }
      [JsonProperty("source")]
      public string Bron { get; set; }

      [JsonProperty("sentiment", ItemConverterType = typeof(DoubleConvert))]
      [NotMapped]
      public IList<double> Sentiment { get; set; }
      [Column("Polariteit")]
      public double Polariteit
      {
         get
         {
            return Sentiment[0];
         }
         set
         {
            Sentiment[0] = value;
         }
      }
      [Column("Objectiviteit")]
      public double Objectiviteit
      {
         get
         {
            return Sentiment[1];
         }
         set
         {
            Sentiment[1] = value;
         }
      }
      public ICollection<string> PersonenJson { get; set; }
      [JsonProperty("persons", ItemConverterType = typeof(PersoonConvert))]
      public ICollection<Persoon> Personen { get; set; }
      [JsonProperty("words", ItemConverterType = typeof(WoordenConvert))]
      public ICollection<Woord> Woorden { get; set; }
      [JsonProperty("urls", ItemConverterType = typeof(UrlConvert))]
      public ICollection<Url> Urls { get; set; }
      [JsonProperty("hashtags", ItemConverterType = typeof(HashtagConvert))]
      public ICollection<Hashtag> Hashtags { get; set; }
      [JsonProperty("mentions", ItemConverterType = typeof(MentionConvert))]
      public ICollection<Mention> Mentions { get; set; }
      [JsonProperty("themes", ItemConverterType = typeof(ThemaConvert))]
      public ICollection<Thema> Themes { get; set; }

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
