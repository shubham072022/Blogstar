using BlogStar.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogStar.Persistence
{
    public static class ConfigurePersistence
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services
            ,IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BlogDb"),
                    builder => builder.MigrationsAssembly(typeof(BlogDbContext).Assembly.FullName));
            });

            return services;
        }
    }
}
