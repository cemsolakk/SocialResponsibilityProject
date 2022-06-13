using System.Collections.Generic;

namespace SCRP.Web.Models.MemberHelpCampaign
{
    public class MemberCampaignListViewModel
    {
        public List<MemberCampaignViewModel> MemberCampaignListViewModels { get; set; }
    }

    public class MemberCampaignViewModel
    {
        public int PostId { get; set; }
        public string CampaignTitle { get; set; }
        public string Pet { get; set; }
        public string Image { get; set; }
        public string DonationMember { get; set; }
        public string DonationValue { get; set; }
        public string DonationIban { get; set; }
        public string DonationDate { get; set; }
        public bool ApprovedByOwner { get; set; }
        public int MemberHelpCampaignId { get; set; }
    }
}