using SCRP.Foundation.Entities;
using System.Web;

namespace SCRP.Web.Models.MemberHelpCampaign
{
    public class MemberCampaignEditViewModel
    {
        public Post Post { get; set; }
        public Pet Pet { get; set; }
        public HelpCampaignDetail HelpCampaignDetail { get; set; }

        public Image Image { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public decimal CampaignUserDonationValue { get; set; }

        public int MemberId { get; set; }

        public int PostId { get; set; }

        public string  PetType { get; set; }
    }
}
