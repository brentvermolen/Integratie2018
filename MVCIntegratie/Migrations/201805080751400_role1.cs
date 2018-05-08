namespace MVCIntegratie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role1 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Series",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        ColorByPoint = c.Boolean(nullable: false),
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
                "dbo.DataSeries",
                c => new
                    {
                        Data_ID = c.Int(nullable: false),
                        Serie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Data_ID, t.Serie_ID })
                .ForeignKey("dbo.Data", t => t.Data_ID, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.Serie_ID, cascadeDelete: true)
                .Index(t => t.Data_ID)
                .Index(t => t.Serie_ID);
            
            CreateTable(
                "dbo.SerieGrafieks",
                c => new
                    {
                        Serie_ID = c.Int(nullable: false),
                        Grafiek_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Serie_ID, t.Grafiek_ID })
                .ForeignKey("dbo.Series", t => t.Serie_ID, cascadeDelete: true)
                .ForeignKey("dbo.Grafieks", t => t.Grafiek_ID, cascadeDelete: true)
                .Index(t => t.Serie_ID)
                .Index(t => t.Grafiek_ID);
            
            CreateTable(
                "dbo.CategorieAs",
                c => new
                    {
                        Categorie_ID = c.Int(nullable: false),
                        As_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Categorie_ID, t.As_ID })
                .ForeignKey("dbo.Categories", t => t.Categorie_ID, cascadeDelete: true)
                .ForeignKey("dbo.As", t => t.As_ID, cascadeDelete: true)
                .Index(t => t.Categorie_ID)
                .Index(t => t.As_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grafieks", "yAs_ID", "dbo.As");
            DropForeignKey("dbo.Grafieks", "xAs_ID", "dbo.As");
            DropForeignKey("dbo.CategorieAs", "As_ID", "dbo.As");
            DropForeignKey("dbo.CategorieAs", "Categorie_ID", "dbo.Categories");
            DropForeignKey("dbo.SerieGrafieks", "Grafiek_ID", "dbo.Grafieks");
            DropForeignKey("dbo.SerieGrafieks", "Serie_ID", "dbo.Series");
            DropForeignKey("dbo.DataSeries", "Serie_ID", "dbo.Series");
            DropForeignKey("dbo.DataSeries", "Data_ID", "dbo.Data");
            DropIndex("dbo.CategorieAs", new[] { "As_ID" });
            DropIndex("dbo.CategorieAs", new[] { "Categorie_ID" });
            DropIndex("dbo.SerieGrafieks", new[] { "Grafiek_ID" });
            DropIndex("dbo.SerieGrafieks", new[] { "Serie_ID" });
            DropIndex("dbo.DataSeries", new[] { "Serie_ID" });
            DropIndex("dbo.DataSeries", new[] { "Data_ID" });
            DropIndex("dbo.Grafieks", new[] { "yAs_ID" });
            DropIndex("dbo.Grafieks", new[] { "xAs_ID" });
            DropTable("dbo.CategorieAs");
            DropTable("dbo.SerieGrafieks");
            DropTable("dbo.DataSeries");
            DropTable("dbo.Categories");
            DropTable("dbo.As");
            DropTable("dbo.Data");
            DropTable("dbo.Series");
            DropTable("dbo.Grafieks");
        }
    }
}
