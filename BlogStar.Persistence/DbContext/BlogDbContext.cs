using BlogStar.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogStar.Persistence.DbContext
{
    public class BlogDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IMediator mediator;
        public BlogDbContext(DbContextOptions<BlogDbContext> options
            , IMediator mediator) : base(options) 
        {
            this.mediator = mediator;
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
