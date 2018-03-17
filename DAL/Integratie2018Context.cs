using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Integratie2018Context : DbContext
   {
      public Integratie2018Context() : base("integratie2018DB")
      {
         Database.SetInitializer<Integratie2018Context>(new Integratie2018Initializer());
      }

      public DbSet<Bericht> Berichten { get; set; }
   }
}
