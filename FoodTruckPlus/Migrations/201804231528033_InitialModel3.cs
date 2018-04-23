namespace FoodTruckPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "ReceiveEmails", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "ReceiveEmails");
        }
    }
}
