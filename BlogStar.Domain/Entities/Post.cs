using BlogStar.Domain.Common;

namespace BlogStar.Domain.Entities
{
    public class Post : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Attachement { get; set; }
        public int AuthorId { get; set; }

        public bool IsPublished { get; set; }

        public virtual List<PostComment> Comments { get; set; }
    }
}
