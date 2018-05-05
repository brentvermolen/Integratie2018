﻿using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
using BL.Domain.GrafiekTypes;
using BL.Domain.ItemKlassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Integratie2018Initializer : CreateDatabaseIfNotExists<Integratie2018Context>
    {
        protected override void Seed(Integratie2018Context context)
        {
            AddGebruikers(context);

            AddAlerts(context);

            AddGrafieken(context);

            context.SaveChanges();
        }

        private void AddGrafieken(Integratie2018Context context)
        {
            Serie serie1 = new Serie() { Naam = "Installation" };
            Data data1 = new Data() { Value = 43934 };
            Data data2 = new Data() { Value = 52503 };
            Data data3 = new Data() { Value = 57177 };
            Data data4 = new Data() { Value = 69658 };
            Data data5 = new Data() { Value = 97031 };
            Data data6 = new Data() { Value = 119931 };
            Data data7 = new Data() { Value = 137133 };
            Data data8 = new Data() { Value = 154175 };
            serie1.Data.Add(data1);
            serie1.Data.Add(data2);
            serie1.Data.Add(data3);
            serie1.Data.Add(data4);
            serie1.Data.Add(data5);
            serie1.Data.Add(data6);
            serie1.Data.Add(data7);
            serie1.Data.Add(data8);

            Serie serie2 = new Serie() { Naam = "Manufacturing" };
            data1 = new Data() { Value = 24916 };
            data2 = new Data() { Value = 24064 };
            data3 = new Data() { Value = 29742 };
            data4 = new Data() { Value = 29851 };
            data5 = new Data() { Value = 32490 };
            data6 = new Data() { Value = 30282 };
            data7 = new Data() { Value = 38121 };
            data8 = new Data() { Value = 40434 };
            serie2.Data.Add(data1);
            serie2.Data.Add(data2);
            serie2.Data.Add(data3);
            serie2.Data.Add(data4);
            serie2.Data.Add(data5);
            serie2.Data.Add(data6);
            serie2.Data.Add(data7);
            serie2.Data.Add(data8);

            Serie serie3 = new Serie() { Naam = "Sales & Distribution" };
            data1 = new Data() { Value = 11744 };
            data2 = new Data() { Value = 17722 };
            data3 = new Data() { Value = 16005 };
            data4 = new Data() { Value = 19771 };
            data5 = new Data() { Value = 20185 };
            data6 = new Data() { Value = 24377 };
            data7 = new Data() { Value = 32147 };
            data8 = new Data() { Value = 39387 };
            serie3.Data.Add(data1);
            serie3.Data.Add(data2);
            serie3.Data.Add(data3);
            serie3.Data.Add(data4);
            serie3.Data.Add(data5);
            serie3.Data.Add(data6);
            serie3.Data.Add(data7);
            serie3.Data.Add(data8);

            Serie serie4 = new Serie() { Naam = "Project Development" };
            data1 = new Data() { Value = 0 };
            data2 = new Data() { Value = 0 };
            data3 = new Data() { Value = 7988 };
            data4 = new Data() { Value = 12169 };
            data5 = new Data() { Value = 15112 };
            data6 = new Data() { Value = 22452 };
            data7 = new Data() { Value = 34400 };
            data8 = new Data() { Value = 34227 };
            serie4.Data.Add(data1);
            serie4.Data.Add(data2);
            serie4.Data.Add(data3);
            serie4.Data.Add(data4);
            serie4.Data.Add(data5);
            serie4.Data.Add(data6);
            serie4.Data.Add(data7);
            serie4.Data.Add(data8);

            Serie serie5 = new Serie() { Naam = "Other" };
            data1 = new Data() { Value = 12908 };
            data2 = new Data() { Value = 5948 };
            data3 = new Data() { Value = 8105 };
            data4 = new Data() { Value = 11248 };
            data5 = new Data() { Value = 8989 };
            data6 = new Data() { Value = 11816 };
            data7 = new Data() { Value = 18274 };
            data8 = new Data() { Value = 18111 };
            serie5.Data.Add(data1);
            serie5.Data.Add(data2);
            serie5.Data.Add(data3);
            serie5.Data.Add(data4);
            serie5.Data.Add(data5);
            serie5.Data.Add(data6);
            serie5.Data.Add(data7);
            serie5.Data.Add(data8);

            List<Serie> series = new List<Serie>();
            series.Add(serie1);
            series.Add(serie2);
            series.Add(serie3);
            series.Add(serie4);
            series.Add(serie5);

            Grafiek grafiek1 = new Lijn(0, "Solar Employment Growth by Sector, 2010-2016", new As()
            { IsUsed = true, Titel = "Number of Employees" }, series);

            As xAs = new As() { IsUsed = true };

            Categorie cat1 = new Categorie("Apples");
            Categorie cat2 = new Categorie("Oranges");
            Categorie cat3 = new Categorie("Pears");
            Categorie cat4 = new Categorie("Grapes");
            Categorie cat5 = new Categorie("Bananas");

            xAs.Categorieen.Add(cat1);
            xAs.Categorieen.Add(cat2);
            xAs.Categorieen.Add(cat3);
            xAs.Categorieen.Add(cat4);
            xAs.Categorieen.Add(cat5);

            serie1 = new Serie() { Naam = "John" };
            data1 = new Data(5);
            data2 = new Data(3);
            data3 = new Data(4);
            data4 = new Data(7);
            data5 = new Data(2);
            serie1.Data.Add(data1);
            serie1.Data.Add(data2);
            serie1.Data.Add(data3);
            serie1.Data.Add(data4);
            serie1.Data.Add(data5);

            serie2 = new Serie() { Naam = "Jane" };
            data1 = new Data(2);
            data2 = new Data(-2);
            data3 = new Data(-3);
            data4 = new Data(2);
            data5 = new Data(1);
            serie2.Data.Add(data1);
            serie2.Data.Add(data2);
            serie2.Data.Add(data3);
            serie2.Data.Add(data4);
            serie2.Data.Add(data5);

            serie3 = new Serie() { Naam = "Joe" };
            data1 = new Data(3);
            data2 = new Data(4);
            data3 = new Data(4);
            data4 = new Data(-2);
            data5 = new Data(5);
            serie3.Data.Add(data1);
            serie3.Data.Add(data2);
            serie3.Data.Add(data3);
            serie3.Data.Add(data4);
            serie3.Data.Add(data5);

            List<Serie> series2 = new List<Serie>();
            series2.Add(serie1);
            series2.Add(serie2);
            series2.Add(serie3);

            Grafiek grafiek2 = new Bar(1, "Column chart with negative values",
               xAs, series2);

            serie1 = new Serie() { Naam = "Brands", ColorByPoint = true };
            data1 = new Data() { Naam = "Chrome", Value = 61.41, Sliced = true, Selected = false };
            data2 = new Data() { Naam = "Internet Explorer", Value = 11.84 };
            data3 = new Data() { Naam = "Firefox", Value = 10.85 };
            data4 = new Data() { Naam = "Edge", Value = 4.67 };
            data5 = new Data() { Naam = "Safari", Value = 4.18 };
            data6 = new Data() { Naam = "Other", Value = 7.05 };
            serie1.Data.Add(data1);
            serie1.Data.Add(data2);
            serie1.Data.Add(data3);
            serie1.Data.Add(data4);
            serie1.Data.Add(data5);
            serie1.Data.Add(data6);

            Grafiek grafiek3 = new Pie(2, "Browser market shares in January, 2018", serie1);

            context.Grafieken.Add(grafiek1);
            context.Grafieken.Add(grafiek2);
            context.Grafieken.Add(grafiek3);

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