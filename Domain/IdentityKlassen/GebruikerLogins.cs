using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.IdentityKlassen
{
    public class GebruikerLogins
    {
        [Key]
        public string LoginProvider { get; set; }
        [Key]
        public string ProviderKey { get; set; }
        [Key]
        [ForeignKey ("Gebruiker")]
        public int GebruikerId { get; set; }
    }
}
