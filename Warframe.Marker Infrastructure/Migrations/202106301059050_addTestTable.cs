namespace Warframe.Market_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                        OrderTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeId, cascadeDelete: true)
                .Index(t => t.OrderTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "OrderTypeId", "dbo.OrderTypes");
            DropIndex("dbo.Tests", new[] { "OrderTypeId" });
            DropTable("dbo.Tests");
            DropTable("dbo.OrderTypes");
        }
    }
}
