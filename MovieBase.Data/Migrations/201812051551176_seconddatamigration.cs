namespace MovieBase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seconddatamigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appearance", "ActorId", "dbo.Actor");
            DropPrimaryKey("dbo.Actor");
            DropColumn("dbo.Actor", "ID");
            DropColumn("dbo.Actor", "UserId");
            AddColumn("dbo.Actor", "ActorId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Actor", "ActorId");
            AddForeignKey("dbo.Appearance", "ActorId", "dbo.Actor", "ActorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appearance", "ActorId", "dbo.Actor");
            DropPrimaryKey("dbo.Actor");
            DropColumn("dbo.Actor", "ActorId");
            AddColumn("dbo.Actor", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Actor", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Actor", "ID");
            AddForeignKey("dbo.Appearance", "ActorId", "dbo.Actor", "ActorId", cascadeDelete: true);
        }
    }
}
