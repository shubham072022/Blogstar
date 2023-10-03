namespace BlogStar.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public int? ModifiedBy { get; set; }
    }
}
