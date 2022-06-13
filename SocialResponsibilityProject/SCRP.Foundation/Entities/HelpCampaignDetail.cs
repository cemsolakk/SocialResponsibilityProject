using SCRP.Foundation.Abstraction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCRP.Foundation.Entities
{
    public class HelpCampaignDetail : EntityBase
    {
   
        
        [Required]
        public string BankAccount { get; set; }

        public bool IsVerifiedByAdmin { get; set; } //kampanya admin tarafından onaylandı mı ?

        public decimal DonationAmount { get; set; }

        public decimal CollectedAmount { get; set; }

        public virtual List<MemberHelpCampaignMapping> MemberHelpCampaignMappings { get; set; }

        public virtual List<Post> Posts { get; set; }

        public HelpCampaignDetail()
        {
            MemberHelpCampaignMappings = new List<MemberHelpCampaignMapping>();

            Posts = new List<Post>();
        }
    }
}
