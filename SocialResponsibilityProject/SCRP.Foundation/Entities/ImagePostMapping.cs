using SCRP.Foundation.Abstraction;

namespace SCRP.Foundation.Entities
{
    public class ImagePostMapping : EntityBase
    {
     

        public int PostId { get; set; }

        public int ImageId { get; set; }

        public virtual Post Post { get; set; }

        public virtual Image Image { get; set; }
    }
}
