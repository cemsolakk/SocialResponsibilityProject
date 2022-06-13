using SCRP.Foundation.Abstraction;

namespace SCRP.Foundation.Entities
{
    public class MemberHelpCampaignMapping : EntityBase
    {
   

       

        public bool MemberVerify { get; set; } // I Sent money

        public bool AdminVerify { get; set; } // I get money

        public decimal CampaignValue { get; set; }

        public int RelatedPostId { get; set; }

        public int MemberId { get; set; }

        public int HelpCampaignDetailId { get; set; }

        public virtual Member Member { get; set; }

        public virtual HelpCampaignDetail HelpCampaignDetail  { get; set; }


    }
}
