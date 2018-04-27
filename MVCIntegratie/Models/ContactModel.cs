using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Web;

namespace MVCIntegratie.Models
{
    public class ContactModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required]
        [Display(Name = "Onderwerp")]
        public string Onderwerp { get; set; }

        [Required]
        [Display(Name = "Bericht")]
        public string Bericht { get; set; }
    }
}