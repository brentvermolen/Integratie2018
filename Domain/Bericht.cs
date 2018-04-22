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
         Themas = new List<Thema>();
         Personen = new List<Persoon>();
         Geo = new double[2];
         Sentiment = new double[2];
      }

      [Key]
      [JsonProperty("id")]
      public string ID { get; set; }
      [JsonProperty("profile")]
      public Profiel Profiel { get; set; }
      [JsonProperty("date")]
      public DateTime Datum { get; set; }
      [NotMapped]
      [JsonIgnore]
      [JsonProperty("geo", ItemConverterType = typeof(DoubleConvert))]
      public double[] Geo { get; set; }

      [Column("Longtitude")]
      public double Longtitude
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

      [JsonIgnore]
      [JsonProperty("sentiment", ItemConverterType = typeof(DoubleConvert))]
      [NotMapped]
      public double[] Sentiment { get; set; }
      [Column("Polariteit")]
      public double Polariteit
      {
         get
         {
            try
            { 
               return Sentiment[0];
            }catch
            {
               return 0;
            }
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
            try
            {
               return Sentiment[1];
            }
            catch
            {
               return 0;
            }
         }
         set
         {
            Sentiment[1] = value;
         }
      }
      [JsonProperty("persons", ItemConverterType = typeof(PersoonConvert))]
      public IList<Persoon> Personen { get; set; }
      [JsonProperty("words", ItemConverterType = typeof(WoordenConvert))]
      public IList<Woord> Woorden { get; set; }
      [JsonProperty("urls", ItemConverterType = typeof(UrlConvert))]
      public IList<Url> Urls { get; set; }
      [JsonProperty("hashtags", ItemConverterType = typeof(HashtagConvert))]
      public IList<Hashtag> Hashtags { get; set; }
      [JsonProperty("mentions", ItemConverterType = typeof(MentionConvert))]
      public IList<Mention> Mentions { get; set; }
      [JsonProperty("themes", ItemConverterType = typeof(ThemaConvert))]
      public IList<Thema> Themas { get; set; }

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
