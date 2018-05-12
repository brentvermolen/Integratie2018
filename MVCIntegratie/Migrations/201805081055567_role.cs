namespace MVCIntegratie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alerts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Verzendwijze = c.String(),
                        Percentage = c.Int(nullable: false),
                        Type = c.String(),
                        Veld = c.String(),
                        VeldWaarde = c.String(),
                        Gebruiker_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gebruikers", t => t.Gebruiker_ID)
                .Index(t => t.Gebruiker_ID);
            
            CreateTable(
                "dbo.Gebruikers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.As",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        IsUsed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tekst = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Berichts",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Profiel_Geslacht = c.String(),
                        Profiel_Leeftijd = c.String(),
                        Profiel_Scholing = c.String(),
                        Profiel_Taal = c.String(),
                        Profiel_Persoonlijkheid = c.String(),
                        Datum = c.DateTime(nullable: false),
                        Longtitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Retweet = c.Boolean(nullable: false),
                        Bron = c.String(),
                        Polariteit = c.Double(nullable: false),
                        Objectiviteit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tekst = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Mentions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tekst = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Persoons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Themas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tekst = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tekst = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Woords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tekst = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Value = c.Double(nullable: false),
                        Sliced = c.Boolean(nullable: false),
                        Selected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        ColorByPoint = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Grafieks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Chart_Type = c.String(),
                        Chart_PlotShadow = c.Boolean(nullable: false),
                        Titel = c.String(),
                        Tooltip = c.String(),
                        Credits = c.Boolean(nullable: false),
                        Legende_Layout = c.String(),
                        Legende_Alignment = c.String(),
                        Legende_VerticalAlign = c.String(),
                        PlotOptions_SeriesLabelConnector = c.Boolean(nullable: false),
                        PlotOptions_PointStart = c.String(),
                        PlotOptions_PointInterval = c.String(),
                        PlotOptions_AllowPointSelect = c.Boolean(nullable: false),
                        PlotOptions_Cursor = c.String(),
                        PlotOptions_DataLabels = c.Boolean(nullable: false),
                        PlotOptions_ShowInLegend = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        xAs_ID = c.Int(),
                        yAs_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.As", t => t.xAs_ID)
                .ForeignKey("dbo.As", t => t.yAs_ID)
                .Index(t => t.xAs_ID)
                .Index(t => t.yAs_ID);
            
            CreateTable(
                "dbo.Synchronizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Latest = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AsCategories",
                c => new
                    {
                        As_ID = c.Int(nullable: false),
                        Categorie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.As_ID, t.Categorie_ID })
                .ForeignKey("dbo.As", t => t.As_ID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Categorie_ID, cascadeDelete: true)
                .Index(t => t.As_ID)
                .Index(t => t.Categorie_ID);
            
            CreateTable(
                "dbo.BerichtHashtags",
                c => new
                    {
                        Bericht_ID = c.String(nullable: false, maxLength: 128),
                        Hashtag_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bericht_ID, t.Hashtag_ID })
                .ForeignKey("dbo.Berichts", t => t.Bericht_ID, cascadeDelete: true)
                .ForeignKey("dbo.Hashtags", t => t.Hashtag_ID, cascadeDelete: true)
                .Index(t => t.Bericht_ID)
                .Index(t => t.Hashtag_ID);
            
            CreateTable(
                "dbo.BerichtMentions",
                c => new
                    {
                        Bericht_ID = c.String(nullable: false, maxLength: 128),
                        Mention_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bericht_ID, t.Mention_ID })
                .ForeignKey("dbo.Berichts", t => t.Bericht_ID, cascadeDelete: true)
                .ForeignKey("dbo.Mentions", t => t.Mention_ID, cascadeDelete: true)
                .Index(t => t.Bericht_ID)
                .Index(t => t.Mention_ID);
            
            CreateTable(
                "dbo.PersoonBerichts",
                c => new
                    {
                        Persoon_ID = c.Int(nullable: false),
                        Bericht_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Persoon_ID, t.Bericht_ID })
                .ForeignKey("dbo.Persoons", t => t.Persoon_ID, cascadeDelete: true)
                .ForeignKey("dbo.Berichts", t => t.Bericht_ID, cascadeDelete: true)
                .Index(t => t.Persoon_ID)
                .Index(t => t.Bericht_ID);
            
            CreateTable(
                "dbo.ThemaBerichts",
                c => new
                    {
                        Thema_ID = c.Int(nullable: false),
                        Bericht_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Thema_ID, t.Bericht_ID })
                .ForeignKey("dbo.Themas", t => t.Thema_ID, cascadeDelete: true)
                .ForeignKey("dbo.Berichts", t => t.Bericht_ID, cascadeDelete: true)
                .Index(t => t.Thema_ID)
                .Index(t => t.Bericht_ID);
            
            CreateTable(
                "dbo.BerichtUrls",
                c => new
                    {
                        Bericht_ID = c.String(nullable: false, maxLength: 128),
                        Url_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bericht_ID, t.Url_ID })
                .ForeignKey("dbo.Berichts", t => t.Bericht_ID, cascadeDelete: true)
                .ForeignKey("dbo.Urls", t => t.Url_ID, cascadeDelete: true)
                .Index(t => t.Bericht_ID)
                .Index(t => t.Url_ID);
            
            CreateTable(
                "dbo.BerichtWoords",
                c => new
                    {
                        Bericht_ID = c.String(nullable: false, maxLength: 128),
                        Woord_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bericht_ID, t.Woord_ID })
                .ForeignKey("dbo.Berichts", t => t.Bericht_ID, cascadeDelete: true)
                .ForeignKey("dbo.Woords", t => t.Woord_ID, cascadeDelete: true)
                .Index(t => t.Bericht_ID)
                .Index(t => t.Woord_ID);
            
            CreateTable(
                "dbo.SerieDatas",
                c => new
                    {
                        Serie_ID = c.Int(nullable: false),
                        Data_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Serie_ID, t.Data_ID })
                .ForeignKey("dbo.Series", t => t.Serie_ID, cascadeDelete: true)
                .ForeignKey("dbo.Data", t => t.Data_ID, cascadeDelete: true)
                .Index(t => t.Serie_ID)
                .Index(t => t.Data_ID);
            
            CreateTable(
                "dbo.GrafiekSeries",
                c => new
                    {
                        Grafiek_ID = c.Int(nullable: false),
                        Serie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Grafiek_ID, t.Serie_ID })
                .ForeignKey("dbo.Grafieks", t => t.Grafiek_ID, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.Serie_ID, cascadeDelete: true)
                .Index(t => t.Grafiek_ID)
                .Index(t => t.Serie_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grafieks", "yAs_ID", "dbo.As");
            DropForeignKey("dbo.Grafieks", "xAs_ID", "dbo.As");
            DropForeignKey("dbo.GrafiekSeries", "Serie_ID", "dbo.Series");
            DropForeignKey("dbo.GrafiekSeries", "Grafiek_ID", "dbo.Grafieks");
            DropForeignKey("dbo.SerieDatas", "Data_ID", "dbo.Data");
            DropForeignKey("dbo.SerieDatas", "Serie_ID", "dbo.Series");
            DropForeignKey("dbo.BerichtWoords", "Woord_ID", "dbo.Woords");
            DropForeignKey("dbo.BerichtWoords", "Bericht_ID", "dbo.Berichts");
            DropForeignKey("dbo.BerichtUrls", "Url_ID", "dbo.Urls");
            DropForeignKey("dbo.BerichtUrls", "Bericht_ID", "dbo.Berichts");
            DropForeignKey("dbo.ThemaBerichts", "Bericht_ID", "dbo.Berichts");
            DropForeignKey("dbo.ThemaBerichts", "Thema_ID", "dbo.Themas");
            DropForeignKey("dbo.PersoonBerichts", "Bericht_ID", "dbo.Berichts");
            DropForeignKey("dbo.PersoonBerichts", "Persoon_ID", "dbo.Persoons");
            DropForeignKey("dbo.BerichtMentions", "Mention_ID", "dbo.Mentions");
            DropForeignKey("dbo.BerichtMentions", "Bericht_ID", "dbo.Berichts");
            DropForeignKey("dbo.BerichtHashtags", "Hashtag_ID", "dbo.Hashtags");
            DropForeignKey("dbo.BerichtHashtags", "Bericht_ID", "dbo.Berichts");
            DropForeignKey("dbo.AsCategories", "Categorie_ID", "dbo.Categories");
            DropForeignKey("dbo.AsCategories", "As_ID", "dbo.As");
            DropForeignKey("dbo.Alerts", "Gebruiker_ID", "dbo.Gebruikers");
            DropIndex("dbo.GrafiekSeries", new[] { "Serie_ID" });
            DropIndex("dbo.GrafiekSeries", new[] { "Grafiek_ID" });
            DropIndex("dbo.SerieDatas", new[] { "Data_ID" });
            DropIndex("dbo.SerieDatas", new[] { "Serie_ID" });
            DropIndex("dbo.BerichtWoords", new[] { "Woord_ID" });
            DropIndex("dbo.BerichtWoords", new[] { "Bericht_ID" });
            DropIndex("dbo.BerichtUrls", new[] { "Url_ID" });
            DropIndex("dbo.BerichtUrls", new[] { "Bericht_ID" });
            DropIndex("dbo.ThemaBerichts", new[] { "Bericht_ID" });
            DropIndex("dbo.ThemaBerichts", new[] { "Thema_ID" });
            DropIndex("dbo.PersoonBerichts", new[] { "Bericht_ID" });
            DropIndex("dbo.PersoonBerichts", new[] { "Persoon_ID" });
            DropIndex("dbo.BerichtMentions", new[] { "Mention_ID" });
            DropIndex("dbo.BerichtMentions", new[] { "Bericht_ID" });
            DropIndex("dbo.BerichtHashtags", new[] { "Hashtag_ID" });
            DropIndex("dbo.BerichtHashtags", new[] { "Bericht_ID" });
            DropIndex("dbo.AsCategories", new[] { "Categorie_ID" });
            DropIndex("dbo.AsCategories", new[] { "As_ID" });
            DropIndex("dbo.Grafieks", new[] { "yAs_ID" });
            DropIndex("dbo.Grafieks", new[] { "xAs_ID" });
            DropIndex("dbo.Alerts", new[] { "Gebruiker_ID" });
            DropTable("dbo.GrafiekSeries");
            DropTable("dbo.SerieDatas");
            DropTable("dbo.BerichtWoords");
            DropTable("dbo.BerichtUrls");
            DropTable("dbo.ThemaBerichts");
            DropTable("dbo.PersoonBerichts");
            DropTable("dbo.BerichtMentions");
            DropTable("dbo.BerichtHashtags");
            DropTable("dbo.AsCategories");
            DropTable("dbo.Synchronizes");
            DropTable("dbo.Grafieks");
            DropTable("dbo.Series");
            DropTable("dbo.Data");
            DropTable("dbo.Woords");
            DropTable("dbo.Urls");
            DropTable("dbo.Themas");
            DropTable("dbo.Persoons");
            DropTable("dbo.Mentions");
            DropTable("dbo.Hashtags");
            DropTable("dbo.Berichts");
            DropTable("dbo.Categories");
            DropTable("dbo.As");
            DropTable("dbo.Gebruikers");
            DropTable("dbo.Alerts");
        }
    }
}
