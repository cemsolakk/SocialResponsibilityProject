using SCRP.Foundation.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCRP.Foundation.Entities
{
    public class Member : EntityBase
    {
  

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Phone { get; set; }

        public string SecondPhone { get; set; }

        [Required]
        public string IBAN { get; set; }

        public virtual List<MemberHelpCampaignMapping> MemberHelpCampaignMappings { get; set; }

        public virtual List<Post> Posts { get; set; }
        public Member()
        {
            MemberHelpCampaignMappings = new List<MemberHelpCampaignMapping>();
            Posts = new List<Post>();
        }


    }
}
