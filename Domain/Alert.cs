using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
    public class Alert
    {
        public int ID { get; set; }
        public virtual Gebruiker Gebruiker { get; set; }
        public virtual Persoon Persoon { get; set; }
        
        public bool VerzendMail { get; set; }
        public bool VerzendBrowser { get; set; }
        public AlertType Type { get; set; }
        public AlertVeld Veld { get; set; }

        public double Verandering { get; set; }

        public virtual Persoon TeVergelijken { get; set; }

        public bool Ingeschakeld { get; set; }

        public enum VerzendWijze
        {
            SMS = 0,
            EMAIL,
            BROWSER
        }

        public enum AlertType
        {
            STIJGING = 0,
            DALING,
            VERGELIJKING,
            BEIDE
        }

        public enum AlertVeld
        {
            AANTAL_BERICHTEN,
            OBJECTIVITEIT,
            SENTIMENT
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
