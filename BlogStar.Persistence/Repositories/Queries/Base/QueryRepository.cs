using BlogStar.Application.Repositories.Queries.Base;
using BlogStar.Domain.Common;
using BlogStar.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogStar.Persistence.Repositories.Queries.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseAuditableEntity, new()
    {
        protected readonly BlogDbContext _dbContext;

        public QueryRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _dbContext.Set<T>().Where(predicate).AnyAsync();
            return result;
        }

        public async Task<IQueryable<T>> GetAllAsync(bool isChangeTracking = false)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (isChangeTracking)
            {
                return query.AsNoTracking().AsQueryable();
            }
            return query.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllWithIncludeAsync(bool isChangeTracking = false, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (isChangeTracking)
            {
                query = predicate is null ? query.AsNoTracking()
                                          : query.Where(predicate).AsNoTracking();
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }
            else
            {
                query = predicate is null ? query
                                          : query.Where(predicate);
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool isChangeTracking = false)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (isChangeTracking)
            {
                query = query.Where(predicate).AsNoTracking();
            }
            else
            {
                query = query.Where(predicate);
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id, bool isChangeTracking = false)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return query.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> GetWithIncludeAsync(bool isChangeTracking, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (isChangeTracking)
            {
                query = query.Where(predicate);
                if (includes is not null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }
            else
            {
                query = query.Where(predicate).AsNoTracking();
                if (includes is not null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }
            }

            return await query.SingleOrDefaultAsync();
        }
    }
}
