namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAndRestaurantTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150, unicode: false),
                        Address = c.String(nullable: false, maxLength: 300, unicode: false),
                        Contact = c.String(maxLength: 50, unicode: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        PasswordHash = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Role = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Restaurants");
        }
    }
}
