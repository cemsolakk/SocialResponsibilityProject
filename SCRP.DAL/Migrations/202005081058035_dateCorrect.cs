namespace SCRP.DataAccessLayer.Concrete.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateCorrect : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.Posts", "MissedDate", c => c.DateTime());
            AlterColumn("dbo.Posts", "CompletedDate", c => c.DateTime());
            AlterColumn("dbo.Pets", "LastSeenDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "LastSeenDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "CompletedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "MissedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Members", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
