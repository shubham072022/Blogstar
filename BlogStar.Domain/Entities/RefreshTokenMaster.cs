using BlogStar.Domain.Common;

namespace BlogStar.Domain.Entities
{
    public class RefreshTokenMaster : BaseEntity
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
