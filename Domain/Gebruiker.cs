using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Domain.IdentityKlassen;


namespace BL.Domain
{
  public partial class Gebruiker
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Gebruiker()
    {
      GebruikerLogins = new HashSet<GebruikerLogin>();
      GebruikersClaims = new HashSet<GebruikersClaim>();
      Roles = new HashSet<Role>();
    }

    public int ID { get; set; }

    public string Voornaam { get; set; }

    public string Achternaam { get; set; }

    public string Geboortedatum { get; set; }

    public string Postcode { get; set; }

    public string Beveiligingsvraag { get; set; }

    public string Antwoord { get; set; }

    [StringLength(256)]
    public string Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PasswordHash { get; set; }

    public string SecurityStamp { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEndDateUtc { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    [StringLength(256)]
    public string UserName { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<GebruikerLogin> GebruikerLogins { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<GebruikersClaim> GebruikersClaims { get; set; }


    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Role> Roles { get; set; }

    public List<Grafiek> Grafieken { get; set; }

    IEnumerable<Alert> Alerts { get; set; }

    public override string ToString()
    {
      if (Voornaam.Equals("") || Achternaam.Equals(""))
      {
        return Email;
      }

      return Voornaam + " " + Achternaam;
    }
  }
}