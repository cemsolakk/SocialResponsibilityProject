using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRP.Foundation.Entities
{
    public class PetType : EntityBase
    {
        public string Name { get; set; }

        public virtual List<Pet> Pets { get; set; }

        public PetType()
        {
            Pets = new List<Pet>();
        }

    }
}
