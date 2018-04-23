namespace FoodTruckPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "UserInfoId");
            AddForeignKey("dbo.Orders", "UserInfoId", "dbo.UserInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserInfoId", "dbo.UserInfoes");
            DropIndex("dbo.Orders", new[] { "UserInfoId" });
            DropColumn("dbo.Orders", "UserInfoId");
        }
    }
}
