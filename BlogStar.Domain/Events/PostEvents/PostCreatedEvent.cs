using BlogStar.Domain.Common;
using BlogStar.Domain.Entities;

namespace BlogStar.Domain.Events.PostEvents
{
    public class PostCreatedEvent : BaseEvent
    {
        public Post Post { get; set; }

        public PostCreatedEvent(Post post) 
        {
            Post = post;
        }
    }
}
