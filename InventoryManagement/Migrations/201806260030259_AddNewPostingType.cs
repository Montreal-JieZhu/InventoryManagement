namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPostingType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PostingTypes VALUES (3, 'GoodReceipt_WorkOrder')");
            Sql("INSERT INTO PostingTypes VALUES (4, 'GoodIssue_SalesOrder')");
        }

        public override void Down()
        {
        }
    }
}
