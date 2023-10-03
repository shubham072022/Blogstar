using BlogStar.Domain.Common;

namespace BlogStar.Domain.Entities
{
    public class PostComment : BaseAuditableEntity
    {
        public int PostId { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public virtual Post Post { get; set; }
    }
}
