namespace MovieBase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appearance", "AppearanceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appearance", "AppearanceId");
        }
    }
}
