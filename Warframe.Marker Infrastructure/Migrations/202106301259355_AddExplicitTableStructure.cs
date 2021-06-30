namespace Warframe.Market_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExplicitTableStructure : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.Translations", "dbo.Translation");
            RenameTable("dbo.Tags", "dbo.Tag");
        }
        
        public override void Down()
        {
            RenameTable("dbo.Translation", "dbo.Translations");
            RenameTable("dbo.Tag", "dbo.Tags");
        }
    }
}
