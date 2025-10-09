namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodItemTblCreaed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FoodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FoodItems");
        }
    }
}
