using BlogStar.Domain.Common;
using BlogStar.Domain.Entities;

namespace BlogStar.Domain.Events.CommentEvents
{
    public class CommentModifiedEvent : BaseEvent
    {
        public PostComment PostComment { get; set; }
        public CommentModifiedEvent(PostComment postComment)
        {
            PostComment = postComment;
        }
    }
}
