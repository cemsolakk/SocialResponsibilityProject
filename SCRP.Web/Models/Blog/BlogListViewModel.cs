using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCRP.Web.Models.Blog
{
    public class BlogListViewModel
    {
        public List<SCRP.Foundation.Entities.Post> Posts { get; set; }
    }
}