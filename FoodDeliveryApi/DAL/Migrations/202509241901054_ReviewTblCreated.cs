namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewTblCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(maxLength: 500, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Reviews", new[] { "RestaurantId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropTable("dbo.Reviews");
        }
    }
}
