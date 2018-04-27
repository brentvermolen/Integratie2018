using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCIntegratie.Models
{
  public class ExternalLoginConfirmationViewModel
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }

  public class ExternalLoginListViewModel
  {
    public string ReturnUrl { get; set; }
  }

  public class SendCodeViewModel
  {
    public string SelectedProvider { get; set; }
    public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    public string ReturnUrl { get; set; }
    public bool RememberMe { get; set; }
  }

  public class VerifyCodeViewModel
  {
    [Required]
    public string Provider { get; set; }

    [Required]
    [Display(Name = "Code")]
    public string Code { get; set; }
    public string ReturnUrl { get; set; }

    [Display(Name = "Remember this browser?")]
    public bool RememberBrowser { get; set; }

    public bool RememberMe { get; set; }
  }

  public class ForgotViewModel
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }

  public class LoginViewModel
  {
    [Display(Name = "Email")]
    [EmailAddress]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
  }

  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Het wachtwoord moet minstens 6 karakters lang zijn.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Het wachtwoord en het herhaalde wachtwoord zijn niet hetzelfde.")]
    public string ConfirmPassword { get; set; }

    [Required]
    [Display(Name = "Voornaam")]
    public string Voornaam { get; set; }

    [Required]
    [Display(Name = "Achternaam")]
    public string Achternaam { get; set; }

    [Required]
    [Display(Name = "Geboortedatum")]
    [RegularExpression("([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0]?[1 - 9]|[1] [0-2])[./-]([0-9]{4}|[0-9]{2})$", ErrorMessage = "De geboortedatum moet van het formaat DD/MM/JJJJ zijn.")]
    public string Geboortedatum { get; set; }

    [Required]
    [Display(Name = "Postcode")]
    [RegularExpression("^[0-9]{4}$", ErrorMessage = "Geef een geldige Postcode in.")]
    public string Postcode { get; set; }

    [Required]
    [Display(Name = "Beveiligingsvraag")]
    public string Beveiligingsvraag { get; set; }

    [Required]
    [Display(Name = "Antwoord")]
    public string Antwoord { get; set; }
  }

  public class ResetPasswordViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Het wachtwoord moet minstens 6 karakters lang zijn.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Het wachtwoord en het herhaalde wachtwoord zijn niet hetzelfde.")]
    public string ConfirmPassword { get; set; }

    public string Code { get; set; }
  }

  public class ForgotPasswordViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}
