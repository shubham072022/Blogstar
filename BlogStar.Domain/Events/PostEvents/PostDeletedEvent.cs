using BlogStar.Domain.Common;
using BlogStar.Domain.Entities;

namespace BlogStar.Domain.Events.PostEvents
{
    public class PostDeletedEvent : BaseEvent
    {
        public Post Post { get; set; }
        public PostDeletedEvent(Post post) { 
            Post = post;
        }
    }
}
