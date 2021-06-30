namespace Warframe.Market_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTextPropertyToTranlsation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Translations", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Translations", "Text");
        }
    }
}
