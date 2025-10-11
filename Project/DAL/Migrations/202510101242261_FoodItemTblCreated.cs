namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodItemTblCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        FoodItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Price = c.Double(nullable: false),
                        Category = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.FoodItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FoodItems");
        }
    }
}
