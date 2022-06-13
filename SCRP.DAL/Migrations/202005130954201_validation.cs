namespace SCRP.DataAccessLayer.Concrete.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HelpCampaignDetails", "BankAccount", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "IBAN", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Pets", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "Name", c => c.String());
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Members", "IBAN", c => c.String());
            AlterColumn("dbo.Members", "Phone", c => c.String());
            AlterColumn("dbo.Members", "Password", c => c.String());
            AlterColumn("dbo.Members", "Email", c => c.String());
            AlterColumn("dbo.Members", "LastName", c => c.String());
            AlterColumn("dbo.Members", "FirstName", c => c.String());
            AlterColumn("dbo.HelpCampaignDetails", "BankAccount", c => c.String());
        }
    }
}
