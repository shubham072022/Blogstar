using BlogStar.Application.Repositories.Commands.Base;
using BlogStar.Domain.Common;
using BlogStar.Persistence.DbContext;

namespace BlogStar.Persistence.Repositories.Commands.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseAuditableEntity, new()
    {
        protected readonly BlogDbContext _dbContext;

        public CommandRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await _dbContext.Set<T>().AddAsync(entity,cancellationToken);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities,cancellationToken);
        }

        public async Task Remove(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task<T> Update(T entity, CancellationToken cancellationToken)
        {
            entity.ModifiedDate = DateTime.UtcNow;
            _dbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
