namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStatusFieldsForWO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WO_Header", "GRStatus", c => c.String());
            DropColumn("dbo.WO_Header", "GIStatus");
            DropColumn("dbo.WO_Item", "GRStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WO_Item", "GRStatus", c => c.String());
            AddColumn("dbo.WO_Header", "GIStatus", c => c.String());
            DropColumn("dbo.WO_Header", "GRStatus");
        }
    }
}
