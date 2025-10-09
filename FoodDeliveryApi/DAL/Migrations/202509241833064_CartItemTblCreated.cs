namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartItemTblCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.FoodItems", t => t.FoodId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.FoodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "FoodId", "dbo.FoodItems");
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropIndex("dbo.CartItems", new[] { "FoodId" });
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropTable("dbo.CartItems");
        }
    }
}
