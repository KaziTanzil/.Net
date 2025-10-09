namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodItems", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.FoodItems", "RestaurantId", c => c.Int(nullable: false));
            CreateIndex("dbo.FoodItems", "CategoryId");
            CreateIndex("dbo.FoodItems", "RestaurantId");
            AddForeignKey("dbo.FoodItems", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.FoodItems", "RestaurantId", "dbo.Restaurants", "RestaurantId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodItems", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.FoodItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.FoodItems", new[] { "RestaurantId" });
            DropIndex("dbo.FoodItems", new[] { "CategoryId" });
            DropColumn("dbo.FoodItems", "RestaurantId");
            DropColumn("dbo.FoodItems", "CategoryId");
        }
    }
}
