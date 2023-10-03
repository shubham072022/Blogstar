using BlogStar.Domain.Common;
using BlogStar.Domain.Entities;

namespace BlogStar.Domain.Events.PostEvents
{
    public class PostModifiedEvent : BaseEvent
    {
        public Post Post { get; set; }
        public PostModifiedEvent(Post post)
        {
            Post = post;
        }
    }
}
