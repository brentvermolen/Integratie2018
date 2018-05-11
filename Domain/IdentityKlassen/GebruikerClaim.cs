using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.IdentityKlassen
{
    public class GebruikerClaim
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("Gebruiker")]
        public int GebruikersId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
