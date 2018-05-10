using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCIntegratie.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class MyUser : IdentityUser<long,MyLogin,MyUserRole,MyClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<MyUser,long> manager)
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //map entities to their tables
            modelBuilder.Entity<MyUser>().ToTable("Gebruikers");
            modelBuilder.Entity<MyRole>().ToTable("Roles");
            modelBuilder.Entity<MyUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<MyClaim>().ToTable("GebruikerClaim");
            modelBuilder.Entity<MyLogin>().ToTable("GebruikerLogin");
            //set autoincrement props
            modelBuilder.Entity<MyUser>().Property(r => r.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MyRole>().Property(r => r.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MyClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

      public System.Data.Entity.DbSet<BL.Domain.Grafiek> Grafieks { get; set; }
   }
}