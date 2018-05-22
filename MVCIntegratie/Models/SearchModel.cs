using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIntegratie.Models
{
    public class SearchModel
    {
    }
    public enum ZoekFilter
    {
        Politieker,
        Trefwoord,
        Mention,
        Tag,
        Link,
        Grafiek

    }

    public enum ZoekSorteren
    {
        AantalBerichten,
        Naam,
        Datum
    }
}