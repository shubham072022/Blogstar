using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogStar.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        private readonly List<BaseEvent> _domainEvent = new();

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvent.AsReadOnly();

        public void AddDomainEvent(BaseEvent domainEvent)
        {
            _domainEvent.Add(domainEvent);
        }

        public void RemoveDomainEvent(BaseEvent domainEvent)
        {
            _domainEvent.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvent.Clear();
        }
    }
}
