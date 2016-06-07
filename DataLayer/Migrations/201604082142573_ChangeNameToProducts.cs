namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameToProducts : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductVersions", newName: "Products");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Products", newName: "ProductVersions");
        }
    }
}
