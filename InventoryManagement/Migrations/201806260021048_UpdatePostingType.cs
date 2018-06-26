namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePostingType : DbMigration
    {
        public override void Up()
        {
            /*
             *  public static readonly byte GoodReceipt_PurchaseOrder = 1;
                public static readonly byte GoodIssue_WorkOrder = 2;
                public static readonly byte GoodReceipt_WorkOrder = 3;
                public static readonly byte GoodIssue_SalesOrder = 4; 
             * 
             */

            Sql("UPDATE PostingTypes SET Type = 'GoodReceipt_PurchaseOrder' WHERE ID = 1");
            Sql("UPDATE PostingTypes SET Type = 'GoodIssue_WorkOrder' WHERE ID = 2");
            
        }

        public override void Down()
        {
        }
    }
}
