namespace Warframe.Market_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateItemTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "OrderTypeId", "dbo.OrderTypes");
            DropIndex("dbo.Tests", new[] { "OrderTypeId" });
            CreateTable(
                "dbo.IconFormats",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UrlName = c.String(),
                        Thumb = c.String(),
                        Ducats = c.Int(nullable: false),
                        TradingTax = c.Int(nullable: false),
                        MasteryLevel = c.Int(nullable: false),
                        Description = c.String(),
                        IconFormat = c.Int(nullable: false),
                        Icon = c.String(),
                        ModMaxRank = c.Int(),
                        ItemName_Id = c.Int(),
                        ParentItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Translations", t => t.ItemName_Id)
                .ForeignKey("dbo.Items", t => t.ParentItem_Id)
                .Index(t => t.ItemName_Id)
                .Index(t => t.ParentItem_Id);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagItems",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Item_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Item_Id);
            
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                        OrderTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TagItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.TagItems", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Items", "ParentItem_Id", "dbo.Items");
            DropForeignKey("dbo.Translations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Items", "ItemName_Id", "dbo.Translations");
            DropIndex("dbo.TagItems", new[] { "Item_Id" });
            DropIndex("dbo.TagItems", new[] { "Tag_Id" });
            DropIndex("dbo.Translations", new[] { "LanguageId" });
            DropIndex("dbo.Items", new[] { "ParentItem_Id" });
            DropIndex("dbo.Items", new[] { "ItemName_Id" });
            DropTable("dbo.TagItems");
            DropTable("dbo.Tags");
            DropTable("dbo.Languages");
            DropTable("dbo.Translations");
            DropTable("dbo.Items");
            DropTable("dbo.IconFormats");
            CreateIndex("dbo.Tests", "OrderTypeId");
            AddForeignKey("dbo.Tests", "OrderTypeId", "dbo.OrderTypes", "Id", cascadeDelete: true);
        }
    }
}
