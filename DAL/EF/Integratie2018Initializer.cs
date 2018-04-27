using BL.Domain;
using BL.Domain.BerichtKlassen;
using BL.Domain.GrafiekKlassen;
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
         context.AddBerichten(1);

         AddGebruikers(context);

         AddAlerts(context);

         AddGrafieken(context);

         context.SaveChanges();
      }

      private void AddGrafieken(Integratie2018Context context)
      {
         Grafiek grafiek1 = new Grafiek()
         {
            ID = "chart1",
            Titel = "Solar Employment Growth by Sector, 2010-2016",
            Subtitel = "Source: thesolarfoundation.com",
            yAs = new As()
            {
               Titel = "Number of Employees",
               IsUsed = true
            },
            Legende = new Legende()
            {
               Layout = "vertical",
               Alignment = "right",
               VerticalAlign = "middle"
            },
            PlotOptions = new PlotOptions()
            {
               SeriesLabelConnector = false,
               PointStart = 2010
            }
         };
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

         data1.Series.Add(serie1);
         data2.Series.Add(serie1);
         data3.Series.Add(serie1);
         data4.Series.Add(serie1);
         data5.Series.Add(serie1);
         data6.Series.Add(serie1);
         data7.Series.Add(serie1);
         data8.Series.Add(serie1);

         context.Series.Add(serie1);
         context.Datas.Add(data1);
         context.Datas.Add(data2);
         context.Datas.Add(data3);
         context.Datas.Add(data4);
         context.Datas.Add(data5);
         context.Datas.Add(data6);
         context.Datas.Add(data7);
         context.Datas.Add(data8);

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

         data1.Series.Add(serie2);
         data2.Series.Add(serie2);
         data3.Series.Add(serie2);
         data4.Series.Add(serie2);
         data5.Series.Add(serie2);
         data6.Series.Add(serie2);
         data7.Series.Add(serie2);
         data8.Series.Add(serie2);

         context.Series.Add(serie2);
         context.Datas.Add(data1);
         context.Datas.Add(data2);
         context.Datas.Add(data3);
         context.Datas.Add(data4);
         context.Datas.Add(data5);
         context.Datas.Add(data6);
         context.Datas.Add(data7);
         context.Datas.Add(data8);

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

         data1.Series.Add(serie3);
         data2.Series.Add(serie3);
         data3.Series.Add(serie3);
         data4.Series.Add(serie3);
         data5.Series.Add(serie3);
         data6.Series.Add(serie3);
         data7.Series.Add(serie3);
         data8.Series.Add(serie3);

         context.Series.Add(serie3);
         context.Datas.Add(data1);
         context.Datas.Add(data2);
         context.Datas.Add(data3);
         context.Datas.Add(data4);
         context.Datas.Add(data5);
         context.Datas.Add(data6);
         context.Datas.Add(data7);
         context.Datas.Add(data8);

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

         data1.Series.Add(serie4);
         data2.Series.Add(serie4);
         data3.Series.Add(serie4);
         data4.Series.Add(serie4);
         data5.Series.Add(serie4);
         data6.Series.Add(serie4);
         data7.Series.Add(serie4);
         data8.Series.Add(serie4);

         context.Series.Add(serie4);
         context.Datas.Add(data1);
         context.Datas.Add(data2);
         context.Datas.Add(data3);
         context.Datas.Add(data4);
         context.Datas.Add(data5);
         context.Datas.Add(data6);
         context.Datas.Add(data7);
         context.Datas.Add(data8);

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

         data1.Series.Add(serie5);
         data2.Series.Add(serie5);
         data3.Series.Add(serie5);
         data4.Series.Add(serie5);
         data5.Series.Add(serie5);
         data6.Series.Add(serie5);
         data7.Series.Add(serie5);
         data8.Series.Add(serie5);

         serie1.Grafieken.Add(grafiek1);
         serie2.Grafieken.Add(grafiek1);
         serie3.Grafieken.Add(grafiek1);
         serie4.Grafieken.Add(grafiek1);
         serie5.Grafieken.Add(grafiek1);

         context.Series.Add(serie5);
         context.Datas.Add(data1);
         context.Datas.Add(data2);
         context.Datas.Add(data3);
         context.Datas.Add(data4);
         context.Datas.Add(data5);
         context.Datas.Add(data6);
         context.Datas.Add(data7);
         context.Datas.Add(data8);

         Grafiek grafiek2 = new Grafiek()
         {
            ID = "chart2",
            Titel = "Column chart with negative values",
            Chart = new Chart() { Type = "column" },
            xAs = new As() { IsUsed = true },
            Credits = false
         };

         Categorie cat1 = new Categorie("Apples");
         Categorie cat2 = new Categorie("Oranges");
         Categorie cat3 = new Categorie("Pears");
         Categorie cat4 = new Categorie("Grapes");
         Categorie cat5 = new Categorie("Bananas");

         grafiek2.xAs.Categorieën.Add(cat1);
         grafiek2.xAs.Categorieën.Add(cat2);
         grafiek2.xAs.Categorieën.Add(cat3);
         grafiek2.xAs.Categorieën.Add(cat4);
         grafiek2.xAs.Categorieën.Add(cat5);

         cat1.Assen.Add(grafiek2.xAs);
         cat2.Assen.Add(grafiek2.xAs);
         cat3.Assen.Add(grafiek2.xAs);
         cat4.Assen.Add(grafiek2.xAs);
         cat5.Assen.Add(grafiek2.xAs);

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

         data1.Series.Add(serie1);
         data2.Series.Add(serie1);
         data3.Series.Add(serie1);
         data4.Series.Add(serie1);
         data5.Series.Add(serie1);

         context.Series.Add(serie1);
         context.Datas.Add(data1);
         context.Datas.Add(data2);
         context.Datas.Add(data3);
         context.Datas.Add(data4);
         context.Datas.Add(data5);

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

         data1.Series.Add(serie2);
         data2.Series.Add(serie2);
         data3.Series.Add(serie2);
         data4.Series.Add(serie2);
         data5.Series.Add(serie2);

         context.Series.Add(serie2);
         context.Datas.Add(data1);
         context.Datas.Add(data2);
         context.Datas.Add(data3);
         context.Datas.Add(data4);
         context.Datas.Add(data5);

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

         data1.Series.Add(serie3);
         data2.Series.Add(serie3);
         data3.Series.Add(serie3);
         data4.Series.Add(serie3);
         data5.Series.Add(serie3);

         serie1.Grafieken.Add(grafiek2);
         serie2.Grafieken.Add(grafiek2);
         serie3.Grafieken.Add(grafiek2);

         context.Series.Add(serie3);
         context.Datas.Add(data1);
         context.Datas.Add(data2);
         context.Datas.Add(data3);
         context.Datas.Add(data4);
         context.Datas.Add(data5);

         Grafiek grafiek3 = new Grafiek()
         {
            ID = "chart3",
            Chart = new Chart()
            {
               PlotShadow = false,
               Type = "pie"
            },
            Titel = "Browser market shares in January, 2018",
            Tooltip = "{series.name}: <b>{point.percentage:.1f}%</b>",
            PlotOptions = new PlotOptions()
            {
               AllowPointSelect = true,
               Cursor = "pointer",
               DataLabels = false,
               ShowInLegend = true
            }
         };
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

         data1.Series.Add(serie1);
         data2.Series.Add(serie1);
         data3.Series.Add(serie1);
         data4.Series.Add(serie1);
         data5.Series.Add(serie1);
         data6.Series.Add(serie1);

         serie1.Grafieken.Add(grafiek3);

         context.Series.Add(serie1);
         context.Datas.Add(data1);
         context.Datas.Add(data2);
         context.Datas.Add(data3);
         context.Datas.Add(data4);
         context.Datas.Add(data5);
         context.Datas.Add(data6);

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
