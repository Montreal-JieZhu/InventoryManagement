namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDConstraintsToTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Materials", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Materials", "Type", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.PO_Header", "Supplier", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PO_Header", "TotalAmount", c => c.Double());
            AlterColumn("dbo.PO_Item", "Price", c => c.Double());
            AlterColumn("dbo.PO_Item", "GRStatus", c => c.String(maxLength: 30));
            AlterColumn("dbo.SO_Header", "Customer", c => c.String(nullable: false));
            AlterColumn("dbo.SO_Header", "TotalAmount", c => c.Double());
            AlterColumn("dbo.SO_Item", "Price", c => c.Double());
            AlterColumn("dbo.SO_Item", "GIStatus", c => c.String(maxLength: 30));
            AlterColumn("dbo.StockPosting_Header", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.StockPosting_Header", "Type", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.StockPosting_Item", "Quantity", c => c.String(nullable: false));
            AlterColumn("dbo.WO_Header", "GRStatus", c => c.String(maxLength: 30));
            AlterColumn("dbo.WO_Item", "GIStatus", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WO_Item", "GIStatus", c => c.String());
            AlterColumn("dbo.WO_Header", "GRStatus", c => c.String());
            AlterColumn("dbo.StockPosting_Item", "Quantity", c => c.String());
            AlterColumn("dbo.StockPosting_Header", "Type", c => c.String());
            AlterColumn("dbo.StockPosting_Header", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SO_Item", "GIStatus", c => c.String());
            AlterColumn("dbo.SO_Item", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.SO_Header", "TotalAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.SO_Header", "Customer", c => c.String());
            AlterColumn("dbo.PO_Item", "GRStatus", c => c.String());
            AlterColumn("dbo.PO_Item", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.PO_Header", "TotalAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.PO_Header", "Supplier", c => c.String());
            AlterColumn("dbo.Materials", "Type", c => c.String());
            AlterColumn("dbo.Materials", "Name", c => c.String());
        }
    }
}
