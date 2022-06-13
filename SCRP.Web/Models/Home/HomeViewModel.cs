using System.Collections.Generic;

namespace SCRP.Web.Models.Home
{
    public class HomeViewModel
    {
        public List<Foundation.Entities.Post> LastPosts { get; set; }

        public int TotalRegisteredPets { get; set; }

        public int TotalFoundedPets { get; set; }

        public decimal TotalCampaingValue { get; set; }
    }
}