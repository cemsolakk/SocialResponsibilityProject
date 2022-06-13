namespace SCRP.DataAccessLayer.Concrete.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class threetableupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HelpCampaignDetails", "DonationAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HelpCampaignDetails", "CollectedAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Members", "Phone", c => c.String());
            AddColumn("dbo.Members", "SecondPhone", c => c.String());
            AddColumn("dbo.Members", "IBAN", c => c.String());
            AddColumn("dbo.Posts", "IsFounded", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "MissedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "Note", c => c.String());
            AddColumn("dbo.Posts", "City", c => c.String());
            AddColumn("dbo.Posts", "District", c => c.String());
            AddColumn("dbo.Posts", "Street", c => c.String());
            AddColumn("dbo.Posts", "Neighbourhood", c => c.String());
            AddColumn("dbo.Posts", "AddressDescription", c => c.String());
            AddColumn("dbo.Pets", "Name", c => c.String());
            AddColumn("dbo.Pets", "IsMale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pets", "Microchipped", c => c.Boolean(nullable: false));
            DropColumn("dbo.HelpCampaignDetails", "TargetValue");
            DropColumn("dbo.Posts", "CreatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HelpCampaignDetails", "TargetValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Pets", "Microchipped");
            DropColumn("dbo.Pets", "IsMale");
            DropColumn("dbo.Pets", "Name");
            DropColumn("dbo.Posts", "AddressDescription");
            DropColumn("dbo.Posts", "Neighbourhood");
            DropColumn("dbo.Posts", "Street");
            DropColumn("dbo.Posts", "District");
            DropColumn("dbo.Posts", "City");
            DropColumn("dbo.Posts", "Note");
            DropColumn("dbo.Posts", "MissedDate");
            DropColumn("dbo.Posts", "IsFounded");
            DropColumn("dbo.Members", "IBAN");
            DropColumn("dbo.Members", "SecondPhone");
            DropColumn("dbo.Members", "Phone");
            DropColumn("dbo.HelpCampaignDetails", "CollectedAmount");
            DropColumn("dbo.HelpCampaignDetails", "DonationAmount");
        }
    }
}
