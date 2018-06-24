namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaterialAndBOMTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BOM_Header",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Materials", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.BOM_Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BOM_HeaderID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BOM_Header", t => t.BOM_HeaderID, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialID, cascadeDelete: false)
                .Index(t => t.BOM_HeaderID)
                .Index(t => t.MaterialID);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BOM_Header", "ProductID", "dbo.Materials");
            DropForeignKey("dbo.BOM_Item", "MaterialID", "dbo.Materials");
            DropForeignKey("dbo.BOM_Item", "BOM_HeaderID", "dbo.BOM_Header");
            DropIndex("dbo.BOM_Item", new[] { "MaterialID" });
            DropIndex("dbo.BOM_Item", new[] { "BOM_HeaderID" });
            DropIndex("dbo.BOM_Header", new[] { "ProductID" });
            DropTable("dbo.Materials");
            DropTable("dbo.BOM_Item");
            DropTable("dbo.BOM_Header");
        }
    }
}
