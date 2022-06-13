namespace SCRP.DataAccessLayer.Concrete.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg2110 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberHelpCampaignMappings", "PostId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberHelpCampaignMappings", "PostId");
        }
    }
}
