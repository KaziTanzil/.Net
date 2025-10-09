namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTblCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false),
                        PaymentMethod = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Orders", t => t.PaymentId)
                .Index(t => t.PaymentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PaymentId", "dbo.Orders");
            DropIndex("dbo.Payments", new[] { "PaymentId" });
            DropTable("dbo.Payments");
        }
    }
}
