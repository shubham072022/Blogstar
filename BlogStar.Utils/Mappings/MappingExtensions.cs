using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogStar.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogStar.Shared.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> ToPaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            where TDestination : class
             => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);

        public static PaginatedList<TDestination> ToPaginatedList<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            where TDestination : class
             => PaginatedList<TDestination>.Create(queryable, pageNumber, pageSize);

        public static async Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            where TDestination : class
            => await queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();

        public static List<TDestination> ProjectToList<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            where TDestination : class
            => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToList();

        public static IQueryable<T> MyOrderBy<T>(this IQueryable<T> source, string columnName, bool isAscending = true)
        {
            if (String.IsNullOrEmpty(columnName))
            {
                return source;
            }
            ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

            MemberExpression property = Expression.Property(parameter, columnName);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = isAscending ? "OrderBy" : "OrderByDescending";

            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                        new Type[] { source.ElementType, property.Type },
                                        source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
    }
}
