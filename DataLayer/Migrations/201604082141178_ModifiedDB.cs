namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductFamilyId", "dbo.ProductFamilies");
            DropForeignKey("dbo.Products", "VersionId", "dbo.SoftwareVersions");
            DropForeignKey("dbo.OrderDetails", "LicenseId", "dbo.Licenses");
            DropForeignKey("dbo.Authorizations", "LicenseId", "dbo.Licenses");
            DropIndex("dbo.Activations", new[] { "Id" });
            DropIndex("dbo.Authorizations", new[] { "LicenseId" });
            DropIndex("dbo.Products", new[] { "ProductFamilyId" });
            DropIndex("dbo.Products", new[] { "VersionId" });
            DropIndex("dbo.OrderDetails", new[] { "LicenseId" });
            DropColumn("dbo.Activations", "AuthorizationId");
            RenameColumn(table: "dbo.Activations", name: "Id", newName: "AuthorizationId");
            DropPrimaryKey("dbo.Activations");
            CreateTable(
                "dbo.ProductVersions",
                c => new
                    {
                        ProductFamilyId = c.Int(nullable: false),
                        VersionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductFamilyId, t.VersionId })
                .ForeignKey("dbo.ProductFamilies", t => t.ProductFamilyId, cascadeDelete: true)
                .ForeignKey("dbo.SoftwareVersions", t => t.VersionId, cascadeDelete: true)
                .Index(t => t.ProductFamilyId)
                .Index(t => t.VersionId);
            
            AddColumn("dbo.Authorizations", "OrderId", c => c.Int());
            AddColumn("dbo.OrderDetails", "Item", c => c.String(nullable: false));
            AlterColumn("dbo.Activations", "Key", c => c.String(nullable: false));
            AlterColumn("dbo.Activations", "AuthorizationId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Authorizations", "LicenseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Licenses", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Activations", "AuthorizationId");
            CreateIndex("dbo.Activations", "AuthorizationId");
            CreateIndex("dbo.Authorizations", "LicenseId");
            CreateIndex("dbo.Authorizations", "OrderId");
            AddForeignKey("dbo.Authorizations", "OrderId", "dbo.Orders", "Id");
            AddForeignKey("dbo.Authorizations", "LicenseId", "dbo.Licenses", "Id", cascadeDelete: true);
            DropColumn("dbo.OrderDetails", "LicenseId");
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductFamilyId = c.Int(nullable: false),
                        VersionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderDetails", "LicenseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Authorizations", "LicenseId", "dbo.Licenses");
            DropForeignKey("dbo.Authorizations", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ProductVersions", "VersionId", "dbo.SoftwareVersions");
            DropForeignKey("dbo.ProductVersions", "ProductFamilyId", "dbo.ProductFamilies");
            DropIndex("dbo.ProductVersions", new[] { "VersionId" });
            DropIndex("dbo.ProductVersions", new[] { "ProductFamilyId" });
            DropIndex("dbo.Authorizations", new[] { "OrderId" });
            DropIndex("dbo.Authorizations", new[] { "LicenseId" });
            DropIndex("dbo.Activations", new[] { "AuthorizationId" });
            DropPrimaryKey("dbo.Activations");
            AlterColumn("dbo.Licenses", "Name", c => c.String());
            AlterColumn("dbo.Authorizations", "LicenseId", c => c.Int());
            AlterColumn("dbo.Activations", "AuthorizationId", c => c.Int());
            AlterColumn("dbo.Activations", "Key", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "Item");
            DropColumn("dbo.Authorizations", "OrderId");
            DropTable("dbo.ProductVersions");
            AddPrimaryKey("dbo.Activations", "Id");
            RenameColumn(table: "dbo.Activations", name: "AuthorizationId", newName: "Id");
            AddColumn("dbo.Activations", "AuthorizationId", c => c.Int());
            CreateIndex("dbo.OrderDetails", "LicenseId");
            CreateIndex("dbo.Products", "VersionId");
            CreateIndex("dbo.Products", "ProductFamilyId");
            CreateIndex("dbo.Authorizations", "LicenseId");
            CreateIndex("dbo.Activations", "Id");
            AddForeignKey("dbo.Authorizations", "LicenseId", "dbo.Licenses", "Id");
            AddForeignKey("dbo.OrderDetails", "LicenseId", "dbo.Licenses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "VersionId", "dbo.SoftwareVersions", "Id");
            AddForeignKey("dbo.Products", "ProductFamilyId", "dbo.ProductFamilies", "Id");
        }
    }
}
