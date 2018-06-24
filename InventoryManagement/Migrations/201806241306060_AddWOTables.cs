namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWOTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WO_Header",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        GIStatus = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Materials", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.WO_Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WO_HeaderID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        GIStatus = c.String(),
                        GRStatus = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Materials", t => t.MaterialID, cascadeDelete: false)
                .ForeignKey("dbo.WO_Header", t => t.WO_HeaderID, cascadeDelete: true)
                .Index(t => t.WO_HeaderID)
                .Index(t => t.MaterialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WO_Item", "WO_HeaderID", "dbo.WO_Header");
            DropForeignKey("dbo.WO_Item", "MaterialID", "dbo.Materials");
            DropForeignKey("dbo.WO_Header", "ProductID", "dbo.Materials");
            DropIndex("dbo.WO_Item", new[] { "MaterialID" });
            DropIndex("dbo.WO_Item", new[] { "WO_HeaderID" });
            DropIndex("dbo.WO_Header", new[] { "ProductID" });
            DropTable("dbo.WO_Item");
            DropTable("dbo.WO_Header");
        }
    }
}
