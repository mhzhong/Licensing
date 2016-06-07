namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        MachineIdentifier = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        BegEffDate = c.DateTime(nullable: false),
                        EndEffDate = c.DateTime(nullable: false),
                        AuthorizationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authorizations", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LicenseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Licenses", t => t.LicenseId)
                .Index(t => t.LicenseId);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 500),
                        TitleOfHardware = c.String(),
                        LicenseType = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ProdFamilyId = c.Int(nullable: false),
                        SubscriptionId = c.Int(nullable: false),
                        VersionId = c.Int(nullable: false),
                        ApplicationId = c.Int(nullable: false),
                        ProductTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.ProductFamilies", t => t.ProdFamilyId, cascadeDelete: true)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Subscriptions", t => t.SubscriptionId, cascadeDelete: true)
                .ForeignKey("dbo.SoftwareVersions", t => t.VersionId, cascadeDelete: true)
                .Index(t => t.ProdFamilyId)
                .Index(t => t.SubscriptionId)
                .Index(t => t.VersionId)
                .Index(t => t.ApplicationId)
                .Index(t => t.ProductTypeId);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        App = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductFamilies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductFamilyId = c.Int(nullable: false),
                        VersionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductFamilies", t => t.ProductFamilyId)
                .ForeignKey("dbo.SoftwareVersions", t => t.VersionId)
                .Index(t => t.ProductFamilyId)
                .Index(t => t.VersionId);
            
            CreateTable(
                "dbo.SoftwareVersions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Version = c.String(nullable: false),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        LicenseId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Licenses", t => t.LicenseId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.LicenseId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                        DatePlacedOrder = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "LicenseId", "dbo.Licenses");
            DropForeignKey("dbo.Authorizations", "LicenseId", "dbo.Licenses");
            DropForeignKey("dbo.Licenses", "VersionId", "dbo.SoftwareVersions");
            DropForeignKey("dbo.Licenses", "SubscriptionId", "dbo.Subscriptions");
            DropForeignKey("dbo.Licenses", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.Licenses", "ProdFamilyId", "dbo.ProductFamilies");
            DropForeignKey("dbo.Products", "VersionId", "dbo.SoftwareVersions");
            DropForeignKey("dbo.Products", "ProductFamilyId", "dbo.ProductFamilies");
            DropForeignKey("dbo.Licenses", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Activations", "Id", "dbo.Authorizations");
            DropIndex("dbo.OrderDetails", new[] { "LicenseId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "VersionId" });
            DropIndex("dbo.Products", new[] { "ProductFamilyId" });
            DropIndex("dbo.Licenses", new[] { "ProductTypeId" });
            DropIndex("dbo.Licenses", new[] { "ApplicationId" });
            DropIndex("dbo.Licenses", new[] { "VersionId" });
            DropIndex("dbo.Licenses", new[] { "SubscriptionId" });
            DropIndex("dbo.Licenses", new[] { "ProdFamilyId" });
            DropIndex("dbo.Authorizations", new[] { "LicenseId" });
            DropIndex("dbo.Activations", new[] { "Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Notifications");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.SoftwareVersions");
            DropTable("dbo.Products");
            DropTable("dbo.ProductFamilies");
            DropTable("dbo.Applications");
            DropTable("dbo.Licenses");
            DropTable("dbo.Authorizations");
            DropTable("dbo.Activations");
        }
    }
}
