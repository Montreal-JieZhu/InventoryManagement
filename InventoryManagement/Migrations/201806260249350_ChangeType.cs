namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StockPosting_Item", "Quantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockPosting_Item", "Quantity", c => c.String(nullable: false));
        }
    }
}
