namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_PO_SO_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PO_Header",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Supplier = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PO_Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PO_HeaderID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        GRStatus = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Materials", t => t.MaterialID, cascadeDelete: false)
                .ForeignKey("dbo.PO_Header", t => t.PO_HeaderID, cascadeDelete: true)
                .Index(t => t.PO_HeaderID)
                .Index(t => t.MaterialID);
            
            CreateTable(
                "dbo.SO_Header",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Customer = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SO_Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SO_HeaderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        GIStatus = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Materials", t => t.ProductID, cascadeDelete: false)
                .ForeignKey("dbo.SO_Header", t => t.SO_HeaderID, cascadeDelete: true)
                .Index(t => t.SO_HeaderID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SO_Item", "SO_HeaderID", "dbo.SO_Header");
            DropForeignKey("dbo.SO_Item", "ProductID", "dbo.Materials");
            DropForeignKey("dbo.PO_Item", "PO_HeaderID", "dbo.PO_Header");
            DropForeignKey("dbo.PO_Item", "MaterialID", "dbo.Materials");
            DropIndex("dbo.SO_Item", new[] { "ProductID" });
            DropIndex("dbo.SO_Item", new[] { "SO_HeaderID" });
            DropIndex("dbo.PO_Item", new[] { "MaterialID" });
            DropIndex("dbo.PO_Item", new[] { "PO_HeaderID" });
            DropTable("dbo.SO_Item");
            DropTable("dbo.SO_Header");
            DropTable("dbo.PO_Item");
            DropTable("dbo.PO_Header");
        }
    }
}
