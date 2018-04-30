using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.ItemKlassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Text;

namespace DAL
{
   public class Integratie2018Initializer  : DropCreateDatabaseIfModelChanges<Integratie2018Context>
   {
      protected override void Seed(Integratie2018Context context)
      {
         context.AddBerichten(100, "Annick De Ridder");

         AddGebruikers(context);

         AddAlerts(context);

         context.SaveChanges();
      }

      private void AddAlerts(Integratie2018Context context)
      {
         Alert a1 = new Alert()
         {
            ID = 0,
            Verzendwijze = "SMS",
            Type = "Trending",
            Veld = "Politieker",
            VeldWaarde = "Annick De Ridder",
            Percentage = 0,
            Gebruiker = context.Gebruikers.Find(0)
         };
         context.Alerts.Add(a1);

         Alert a2 = new Alert()
         {
            ID = 1,
            Verzendwijze = "Applicatie",
            Type = "Aantal",
            Veld = "Politieker",
            VeldWaarde = "Annick De Ridder",
            Percentage = 5,
            Gebruiker = context.Gebruikers.Find(0)
         };
         context.Alerts.Add(a2);

         Alert a3 = new Alert()
         {
            ID = 2,
            Verzendwijze = "E-Mail",
            Type = "Trending",
            Veld = "Politieker",
            VeldWaarde = "Annick De Ridder",
            Percentage = 0,
            Gebruiker = context.Gebruikers.Find(1)
         };
         context.Alerts.Add(a3);

         Alert a4 = new Alert()
         {
            ID = 3,
            Verzendwijze = "Browser",
            Type = "Aantal",
            Veld = "Politieker",
            VeldWaarde = "Annick De Ridder",
            Percentage = 5,
            Gebruiker = context.Gebruikers.Find(1)
         };
         context.Alerts.Add(a4);
      }

      private void AddGebruikers(Integratie2018Context context)
      {
         Gebruiker g1 = new Gebruiker()
         {
            ID = 0,
            Naam = "Eddy"
         };
         context.Gebruikers.Add(g1);

         Gebruiker g2 = new Gebruiker()
         {
            ID = 1,
            Naam = "Jan"
         };
         context.Gebruikers.Add(g2);
      }
   }
}
