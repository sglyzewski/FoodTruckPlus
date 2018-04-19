namespace FoodTruckPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMinutesColumn : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Orders ADD MinutesUntilReady INT NULL");
        }
        
        public override void Down()
        {
        }
    }
}
