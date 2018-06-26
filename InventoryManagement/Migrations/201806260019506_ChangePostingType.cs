namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePostingType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockPosting_Header", "PostingTypeID", c => c.Byte(nullable: false));
            CreateIndex("dbo.StockPosting_Header", "PostingTypeID");
            AddForeignKey("dbo.StockPosting_Header", "PostingTypeID", "dbo.PostingTypes", "ID", cascadeDelete: true);
            DropColumn("dbo.StockPosting_Header", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockPosting_Header", "Type", c => c.String(nullable: false, maxLength: 5));
            DropForeignKey("dbo.StockPosting_Header", "PostingTypeID", "dbo.PostingTypes");
            DropIndex("dbo.StockPosting_Header", new[] { "PostingTypeID" });
            DropColumn("dbo.StockPosting_Header", "PostingTypeID");
        }
    }
}
