using BlogStar.Domain.Entities;
using BlogStar.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogStar.Identity.DbContext
{
    public class BlogIdentityDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        private readonly IMediator mediator;
        public BlogIdentityDbContext(DbContextOptions<BlogIdentityDbContext> options,
            IMediator mediator) : base(options) 
        {
            this.mediator = mediator;
        }

        public DbSet<RefreshTokenMaster> RefreshTokenMaster { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public string GetConnectionString { get => this.Database.GetDbConnection().ConnectionString; }
    }
}
