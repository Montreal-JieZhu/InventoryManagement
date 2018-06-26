namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaterialCodeIntoMaterialTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "MaterialCode", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "MaterialCode");
        }
    }
}
