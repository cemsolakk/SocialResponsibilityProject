using SCRP.Foundation.Abstraction;
using SCRP.Foundation.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCRP.Foundation.Entities
{
    public class Post : EntityBase
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public int PostTypeId { get; set; }

        public virtual PostType PostType { get; set; }

     

        [Required]
        public string Content { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsFounded { get; set; }

        public DateTime MissedDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

        public int MemberId { get; set; }

        public virtual Member Member { get; set; }

        public virtual HelpCampaignDetail HelpCampaignDetail { get; set; }

        public int HelpCampaignDetailId { get; set; }

       

        public string Note { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string Neighbourhood { get; set; }

        public string AddressDescription { get; set; }

        public List<ImagePostMapping> ImagePostMappings { get; set; }

        public Post()
        {
            ImagePostMappings = new List<ImagePostMapping>();
        }
    }
}
