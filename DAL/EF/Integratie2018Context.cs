using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using BL.Domain.ItemKlassen;
using BL.Domain.IdentityKlassen;
using System;
using System.Data.Entity;

namespace DAL
{

   public class Integratie2018Context : DbContext
   {
      public static int Count = 0;
      public static Synchronize sync;


      public Integratie2018Context() : base("integratie2018DB")
      {
         Database.SetInitializer(new Integratie2018Initializer());

         try
         {
            Database.Initialize(false);
         }
         catch (Exception e)
         {
            e.ToString();
         }

         /*if (Count++ == 0)
         {
            sync = Sync.Find(0);
            if (sync == null)
            {
               sync = new Synchronize()
               {
                  ID = 0,
                  Latest = new DateTime(2018, 1, 1),
                  Context = this
               };
               Sync.Add(sync);
               SaveChanges();
               sync.Start();
            }
            else
            {
               sync.Start();
            }
         }*/
      }


      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Bericht>()
            .HasMany(b => b.Woorden)
            .WithMany(t => t.Berichten);
         modelBuilder.Entity<Bericht>()
            .HasMany(b => b.Urls)
            .WithMany(u => u.Berichten);
         modelBuilder.Entity<Bericht>()
            .HasMany(b => b.Mentions)
            .WithMany(m => m.Berichten);
         modelBuilder.Entity<Bericht>()
            .HasMany(b => b.Hashtags)
            .WithMany(h => h.Berichten);


         modelBuilder.Entity<Grafiek>()
            .HasMany(g => g.Series)
            .WithMany(s => s.Grafieken);
         modelBuilder.Entity<Serie>()
            .HasMany(s => s.Data)
            .WithMany(d => d.Series);
         modelBuilder.Entity<As>()
            .HasMany(a => a.Categorieen)
            .WithMany(c => c.Assen);

            modelBuilder.Entity<Gebruiker>()
                .HasMany(e => e.GebruikersClaims)
                .WithRequired(e => e.Gebruiker)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Gebruiker>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Gebruikers)
                .Map(m => m.ToTable("GebruikerRoles").MapLeftKey("UserId").MapRightKey("RoleId"));



            base.OnModelCreating(modelBuilder);
      }


      public DbSet<Synchronize> Sync { get; set; }

      public DbSet<Bericht> Berichten { get; set; }
      public DbSet<Woord> Woorden { get; set; }
      public DbSet<Url> Urls { get; set; }
      public DbSet<Mention> Mentions { get; set; }
      public DbSet<Hashtag> Hashtags { get; set; }
      public DbSet<Thema> Themas { get; set; }

      public DbSet<Persoon> Personen { get; set; }

      


      public DbSet<Alert> Alerts { get; set; }

        public virtual DbSet<GebruikerLogin> GebruikerLogins { get; set; }
        public virtual DbSet<Gebruiker> Gebruikers { get; set; }
        public virtual DbSet<GebruikersClaim> GebruikersClaims { get; set; }
        public virtual DbSet<Role> Roles { get; set; }


        public DbSet<Grafiek> Grafieken { get; set; }
      public DbSet<Serie> Series { get; set; }
      public DbSet<Data> Datas { get; set; }
      public DbSet<As> Assen { get; set; }
      public DbSet<Categorie> Categorieën { get; set; }

      public DbSet<FAQ> FAQ { get; set; }
   }
}