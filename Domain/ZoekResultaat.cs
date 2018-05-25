using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Domain;
using BL.Domain.BerichtKlassen;

using System.Web;
using BL.Domain.PersoonKlassen;

namespace BL.Domain
{
    
    public class ZoekResultaat
    {
        public ZoekResultaat()
        {
            Woorden = new List<Woord>();
            Urls = new List<Url>();
            Mentions = new List<Mention>();
            Hashtags = new List<Hashtag>();
            Personen = new List<Persoon>();
            Grafieken = new List<Grafiek>();
            Organisaties = new List<Organisatie>();


        }


        public List<Woord> Woorden { get; set; }
        public List<Hashtag> Hashtags { get; set; }
        public List<Mention> Mentions { get; set; }
        public List<Url> Urls { get; set; }
        public List<Grafiek> Grafieken { get; set; }
        public List<Persoon> Personen { get; set; }
        public List<Organisatie> Organisaties { get; set; }
    }

    public enum ZoekFilter
    {
        Politieker,
        Organisatie,
        Trefwoord,
        Mention,
        Tag,
        Link,
        Grafiek

    }

    public enum ZoekSorteren
    {
        AantalBerichten,
        Naam
    }
}
