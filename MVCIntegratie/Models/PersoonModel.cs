using BL.Domain;
using BL.Domain.BerichtKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIntegratie.Models
{
    public class PersoonModel
    {
        public Persoon Persoon { get; set; }
        public Grafiek Grafiek { get; set; }
        public List<Woord> Keywoorden { get; set; }
        public List<Url> Urls { get; set; }
    }
}