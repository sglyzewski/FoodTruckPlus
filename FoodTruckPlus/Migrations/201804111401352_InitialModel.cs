namespace FoodTruckPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodTrucks", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.MenuItems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.FoodTrucks", new[] { "MenuId" });
            DropIndex("dbo.MenuItems", new[] { "Order_Id" });
            CreateTable(
                "dbo.FullMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientItem = c.String(),
                        MenuItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId, cascadeDelete: true)
                .Index(t => t.MenuItemId);
            
            AddColumn("dbo.FoodTrucks", "FullMenuId", c => c.Int(nullable: false));
            AddColumn("dbo.MenuItems", "FullMenuId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "MenuItems", c => c.String());
            AddColumn("dbo.UserInfoes", "UserId", c => c.String());
            CreateIndex("dbo.FoodTrucks", "FullMenuId");
            CreateIndex("dbo.MenuItems", "FullMenuId");
            AddForeignKey("dbo.FoodTrucks", "FullMenuId", "dbo.FullMenus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuItems", "FullMenuId", "dbo.FullMenus", "Id", cascadeDelete: true);
            DropColumn("dbo.FoodTrucks", "MenuId");
            DropColumn("dbo.MenuItems", "Order_Id");
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.MenuItems", "Order_Id", c => c.Int());
            AddColumn("dbo.FoodTrucks", "MenuId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ingredients", "MenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "FullMenuId", "dbo.FullMenus");
            DropForeignKey("dbo.FoodTrucks", "FullMenuId", "dbo.FullMenus");
            DropIndex("dbo.MenuItems", new[] { "FullMenuId" });
            DropIndex("dbo.Ingredients", new[] { "MenuItemId" });
            DropIndex("dbo.FoodTrucks", new[] { "FullMenuId" });
            DropColumn("dbo.UserInfoes", "UserId");
            DropColumn("dbo.Orders", "MenuItems");
            DropColumn("dbo.MenuItems", "FullMenuId");
            DropColumn("dbo.FoodTrucks", "FullMenuId");
            DropTable("dbo.Ingredients");
            DropTable("dbo.FullMenus");
            CreateIndex("dbo.MenuItems", "Order_Id");
            CreateIndex("dbo.FoodTrucks", "MenuId");
            AddForeignKey("dbo.MenuItems", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.FoodTrucks", "MenuId", "dbo.Menus", "ID", cascadeDelete: true);
        }
    }
}
