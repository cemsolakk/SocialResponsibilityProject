using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRP.Foundation.Entities
{
    public class PostType : EntityBase
    {
        public string TypeName { get; set; }

        public virtual List<Post> Posts { get; set; }

        public PostType()
        {
            Posts = new List<Post>();
        }


    }
}
