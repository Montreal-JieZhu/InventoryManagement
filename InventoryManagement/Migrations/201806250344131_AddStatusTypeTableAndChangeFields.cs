namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusTypeTableAndChangeFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostingTypes",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Materials", "MaterialTypeID", c => c.Byte(nullable: false));
            AddColumn("dbo.PO_Item", "StatusID", c => c.Byte(nullable: false));
            AddColumn("dbo.SO_Item", "StatusID", c => c.Byte(nullable: false));
            AddColumn("dbo.WO_Header", "StatusID", c => c.Byte(nullable: false));
            AddColumn("dbo.WO_Item", "StatusID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Materials", "MaterialTypeID");
            CreateIndex("dbo.PO_Item", "StatusID");
            CreateIndex("dbo.SO_Item", "StatusID");
            CreateIndex("dbo.WO_Header", "StatusID");
            CreateIndex("dbo.WO_Item", "StatusID");
            AddForeignKey("dbo.Materials", "MaterialTypeID", "dbo.MaterialTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PO_Item", "StatusID", "dbo.Status", "ID", cascadeDelete: true);
            AddForeignKey("dbo.SO_Item", "StatusID", "dbo.Status", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WO_Header", "StatusID", "dbo.Status", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WO_Item", "StatusID", "dbo.Status", "ID", cascadeDelete: false);
            DropColumn("dbo.Materials", "Type");
            DropColumn("dbo.PO_Item", "GRStatus");
            DropColumn("dbo.SO_Item", "GIStatus");
            DropColumn("dbo.WO_Header", "GRStatus");
            DropColumn("dbo.WO_Item", "GIStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WO_Item", "GIStatus", c => c.String(maxLength: 30));
            AddColumn("dbo.WO_Header", "GRStatus", c => c.String(maxLength: 30));
            AddColumn("dbo.SO_Item", "GIStatus", c => c.String(maxLength: 30));
            AddColumn("dbo.PO_Item", "GRStatus", c => c.String(maxLength: 30));
            AddColumn("dbo.Materials", "Type", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.WO_Item", "StatusID", "dbo.Status");
            DropForeignKey("dbo.WO_Header", "StatusID", "dbo.Status");
            DropForeignKey("dbo.SO_Item", "StatusID", "dbo.Status");
            DropForeignKey("dbo.PO_Item", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Materials", "MaterialTypeID", "dbo.MaterialTypes");
            DropIndex("dbo.WO_Item", new[] { "StatusID" });
            DropIndex("dbo.WO_Header", new[] { "StatusID" });
            DropIndex("dbo.SO_Item", new[] { "StatusID" });
            DropIndex("dbo.PO_Item", new[] { "StatusID" });
            DropIndex("dbo.Materials", new[] { "MaterialTypeID" });
            DropColumn("dbo.WO_Item", "StatusID");
            DropColumn("dbo.WO_Header", "StatusID");
            DropColumn("dbo.SO_Item", "StatusID");
            DropColumn("dbo.PO_Item", "StatusID");
            DropColumn("dbo.Materials", "MaterialTypeID");
            DropTable("dbo.PostingTypes");
            DropTable("dbo.Status");
            DropTable("dbo.MaterialTypes");
        }
    }
}
