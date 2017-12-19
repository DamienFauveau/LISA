namespace LISA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalogues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Type = c.String(),
                        Label = c.String(),
                        Witdh = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        Op_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationCommerciales", t => t.Op_Id)
                .Index(t => t.Op_Id);
            
            CreateTable(
                "dbo.Magasins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ville = c.String(),
                        CodePostal = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        Ville = c.String(),
                        CodePostal = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperationCommerciales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Title = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Catalogue_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catalogues", t => t.Catalogue_Id)
                .Index(t => t.Catalogue_Id);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Label = c.String(),
                        Description = c.String(),
                        Category = c.String(),
                        Price = c.Single(nullable: false),
                        ReductionPercent = c.Int(nullable: false),
                        AvantagePercent = c.Int(nullable: false),
                        Ecotaxe = c.Int(nullable: false),
                        Image = c.String(),
                        Picto = c.String(),
                        Origin = c.String(),
                        Mention = c.String(),
                        Packaging = c.String(),
                        Lowerprice = c.Int(nullable: false),
                        Color = c.String(),
                        ReductionEuro = c.Int(nullable: false),
                        AvantageEuro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CoordX = c.Int(nullable: false),
                        CoordY = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Produit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produits", t => t.Produit_Id)
                .Index(t => t.Produit_Id);
            
            CreateTable(
                "dbo.TypeSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        Telephone = c.Int(nullable: false),
                        Password = c.String(),
                        TypeSalarie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeSalaries", t => t.TypeSalarie_Id)
                .Index(t => t.TypeSalarie_Id);
            
            CreateTable(
                "dbo.MagasinCatalogues",
                c => new
                    {
                        Magasin_Id = c.Int(nullable: false),
                        Catalogue_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Magasin_Id, t.Catalogue_Id })
                .ForeignKey("dbo.Magasins", t => t.Magasin_Id, cascadeDelete: true)
                .ForeignKey("dbo.Catalogues", t => t.Catalogue_Id, cascadeDelete: true)
                .Index(t => t.Magasin_Id)
                .Index(t => t.Catalogue_Id);
            
            CreateTable(
                "dbo.ClientMagasins",
                c => new
                    {
                        Client_Id = c.Int(nullable: false),
                        Magasin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_Id, t.Magasin_Id })
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Magasins", t => t.Magasin_Id, cascadeDelete: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Magasin_Id);
            
            CreateTable(
                "dbo.ProduitPages",
                c => new
                    {
                        Produit_Id = c.Int(nullable: false),
                        Page_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produit_Id, t.Page_Id })
                .ForeignKey("dbo.Produits", t => t.Produit_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pages", t => t.Page_Id, cascadeDelete: true)
                .Index(t => t.Produit_Id)
                .Index(t => t.Page_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "TypeSalarie_Id", "dbo.TypeSalaries");
            DropForeignKey("dbo.Pages", "Catalogue_Id", "dbo.Catalogues");
            DropForeignKey("dbo.Zones", "Produit_Id", "dbo.Produits");
            DropForeignKey("dbo.ProduitPages", "Page_Id", "dbo.Pages");
            DropForeignKey("dbo.ProduitPages", "Produit_Id", "dbo.Produits");
            DropForeignKey("dbo.Catalogues", "Op_Id", "dbo.OperationCommerciales");
            DropForeignKey("dbo.ClientMagasins", "Magasin_Id", "dbo.Magasins");
            DropForeignKey("dbo.ClientMagasins", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.MagasinCatalogues", "Catalogue_Id", "dbo.Catalogues");
            DropForeignKey("dbo.MagasinCatalogues", "Magasin_Id", "dbo.Magasins");
            DropIndex("dbo.ProduitPages", new[] { "Page_Id" });
            DropIndex("dbo.ProduitPages", new[] { "Produit_Id" });
            DropIndex("dbo.ClientMagasins", new[] { "Magasin_Id" });
            DropIndex("dbo.ClientMagasins", new[] { "Client_Id" });
            DropIndex("dbo.MagasinCatalogues", new[] { "Catalogue_Id" });
            DropIndex("dbo.MagasinCatalogues", new[] { "Magasin_Id" });
            DropIndex("dbo.Salaries", new[] { "TypeSalarie_Id" });
            DropIndex("dbo.Zones", new[] { "Produit_Id" });
            DropIndex("dbo.Pages", new[] { "Catalogue_Id" });
            DropIndex("dbo.Catalogues", new[] { "Op_Id" });
            DropTable("dbo.ProduitPages");
            DropTable("dbo.ClientMagasins");
            DropTable("dbo.MagasinCatalogues");
            DropTable("dbo.Salaries");
            DropTable("dbo.TypeSalaries");
            DropTable("dbo.Zones");
            DropTable("dbo.Produits");
            DropTable("dbo.Pages");
            DropTable("dbo.OperationCommerciales");
            DropTable("dbo.Clients");
            DropTable("dbo.Magasins");
            DropTable("dbo.Catalogues");
        }
    }
}
