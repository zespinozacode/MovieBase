namespace MovieBase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdatamigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actor", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Appearance", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Movie", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "UserId");
            DropColumn("dbo.Appearance", "UserId");
            DropColumn("dbo.Actor", "UserId");
        }
    }
}
