namespace FoodTruckPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedOrders : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Orders (Price, Paid, TimePurchased, TimeDesiredReady, MenuItems, MinutesUntilReady) VALUES (2.50, 'true', 01-01-2018, 01-01-2018, 'hot dog, taco', 30)");
        }
        
        public override void Down()
        {
        }
    }
}
