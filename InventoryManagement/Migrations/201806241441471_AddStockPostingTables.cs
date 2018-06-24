namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockPostingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockPosting_Header",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReferenceOrderID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StockPosting_Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StockPosting_HeaderID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        Quantity = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Materials", t => t.MaterialID, cascadeDelete: false)
                .ForeignKey("dbo.StockPosting_Header", t => t.StockPosting_HeaderID, cascadeDelete: true)
                .Index(t => t.StockPosting_HeaderID)
                .Index(t => t.MaterialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockPosting_Item", "StockPosting_HeaderID", "dbo.StockPosting_Header");
            DropForeignKey("dbo.StockPosting_Item", "MaterialID", "dbo.Materials");
            DropIndex("dbo.StockPosting_Item", new[] { "MaterialID" });
            DropIndex("dbo.StockPosting_Item", new[] { "StockPosting_HeaderID" });
            DropTable("dbo.StockPosting_Item");
            DropTable("dbo.StockPosting_Header");
        }
    }
}
