using SCRP.Foundation.Abstraction;
using System.Collections.Generic;

namespace SCRP.Foundation.Entities
{
    public class Image : EntityBase
    {
     

        public string Path { get; set; }

        public virtual List<ImagePostMapping> ImagePostMappings { get; set; }

        public Image()
        {
            ImagePostMappings = new List<ImagePostMapping>();
        }
    }
}