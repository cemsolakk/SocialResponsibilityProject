using SCRP.Foundation.Entities;
using System.Web;

namespace SCRP.Web.Models.Member
{
    public class MemberAdvertisementEditViewModel
    {
        public Pet Pet { get; set; }

        public SCRP.Foundation.Entities.Post Post { get; set; }

        public Image Image { get; set; }
        
        public HttpPostedFileBase ImageFile { get; set; }
    }
}