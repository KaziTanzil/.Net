namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeliveryTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false),
                        DeliveryBoyId = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.DeliveryId)
                .ForeignKey("dbo.Users", t => t.DeliveryBoyId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.DeliveryId)
                .Index(t => t.DeliveryId)
                .Index(t => t.DeliveryBoyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deliveries", "DeliveryId", "dbo.Orders");
            DropForeignKey("dbo.Deliveries", "DeliveryBoyId", "dbo.Users");
            DropIndex("dbo.Deliveries", new[] { "DeliveryBoyId" });
            DropIndex("dbo.Deliveries", new[] { "DeliveryId" });
            DropTable("dbo.Deliveries");
        }
    }
}
