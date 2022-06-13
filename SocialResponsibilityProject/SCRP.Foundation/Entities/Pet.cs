using SCRP.Foundation.Abstraction;
using SCRP.Foundation.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCRP.Foundation.Entities
{
    public class Pet : EntityBase
    {
    
     

        [Required]
        public string Name { get; set; }

        public bool IsMale { get; set; }

        public string Strain { get; set; }

        public int Age { get; set; }

        public string Color { get; set; }

        public bool Microchipped { get; set; }

        public decimal Height { get; set; }
        
        public decimal Weight { get; set; }

        public DateTime? LastSeenDate { get; set; }

        public string LastSeenLocation { get; set; }

        public bool IsFounded { get; set; }

        public virtual PetType PetType { get; set; }

        public int PetTypeId { get; set; }

        public virtual List<Post> Posts { get; set; }

        public Pet()
        {
            Posts = new List<Post>();
        }

    }
}