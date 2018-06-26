namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDataForTypeAndStatusTable : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO MaterialTypes VALUES(1, 'Raw Material')");
            Sql("INSERT INTO MaterialTypes VALUES(2, 'Finished Product')");

            Sql("INSERT INTO PostingTypes VALUES(1, 'Good Receipt')");
            Sql("INSERT INTO PostingTypes VALUES(2, 'Good Issue')");

            Sql("INSERT INTO Status VALUES(1, 'Not Start')");
            Sql("INSERT INTO Status VALUES(2, 'In Processing')");
            Sql("INSERT INTO Status VALUES(3, 'Completed')");
        }
        
        public override void Down()
        {
        }
    }
}
