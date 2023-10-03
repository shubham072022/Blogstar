using BlogStar.Domain.Common;

namespace BlogStar.Application.Repositories.Commands.Base
{
    public interface ICommandRepository<T> where T : BaseAuditableEntity, new()
    {
        Task<T> AddAsync(T entity,CancellationToken cancellationToken);
        Task AddRangeAsync(IEnumerable<T> entities,CancellationToken cancellationToken);

        Task<T> Update(T entity,CancellationToken cancellationToken);

        Task Remove(T entity,CancellationToken cancellationToken);

        Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    }
}
