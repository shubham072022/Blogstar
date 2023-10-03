using BlogStar.Domain.Common;
using BlogStar.Domain.Entities;

namespace BlogStar.Domain.Events.CommentEvents
{
    public class CommentDeletedEvent : BaseEvent
    {
        public PostComment PostComment { get; set; }
        public CommentDeletedEvent(PostComment postComment)
        {
            PostComment = postComment;
        }
    }
}
