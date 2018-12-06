namespace MovieBase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thanksluke : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Appearance");
            AlterColumn("dbo.Appearance", "AppearanceId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Appearance", new[] { "ActorId", "MovieId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Appearance");
            AlterColumn("dbo.Appearance", "AppearanceId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Appearance", "AppearanceId");
        }
    }
}
