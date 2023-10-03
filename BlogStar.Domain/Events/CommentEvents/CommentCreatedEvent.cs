using BlogStar.Domain.Common;
using BlogStar.Domain.Entities;

namespace BlogStar.Domain.Events.CommentEvents
{
    public class CommentCreatedEvent : BaseEvent
    {
        public PostComment PostComment { get; set; }
        public CommentCreatedEvent(PostComment postComment)
        {
            PostComment = postComment;
        }
    }
}
