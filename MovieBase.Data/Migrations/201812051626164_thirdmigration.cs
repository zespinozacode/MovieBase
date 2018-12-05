namespace MovieBase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actor", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actor", "UserId");
        }
    }
}
