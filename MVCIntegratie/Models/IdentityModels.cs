using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCIntegratie.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class MyUser : IdentityUser<int,MyLogin,MyUserRole,MyClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Geboortedatum { get; set; }

        public string Postcode { get; set; }

        public string Beveiligingsvraag { get; set; }

        public string Antwoord { get; set; }
    }
    public class MyUserRole : IdentityUserRole<long> { }

    public class MyRole : IdentityRole<long,MyUserRole> { }

    public class MyClaim : IdentityUserClaim<long>
    {
   
    }
    public class MyLogin : IdentityUserLogin<long> { }

    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole() : base (){ }
        public ApplicationRole(string roleName):base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<MyUser,MyRole,long,MyLogin,MyUserRole,MyClaim>
    {
        public ApplicationDbContext()
            : base("integratie2018DB")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

      public System.Data.Entity.DbSet<BL.Domain.Grafiek> Grafieks { get; set; }
   }
}