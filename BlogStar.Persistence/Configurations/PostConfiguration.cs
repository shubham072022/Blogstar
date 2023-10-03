using BlogStar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogStar.Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x =>  x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Attachement).IsRequired();
            builder.Property(x => x.AuthorId).IsRequired();
            builder.HasMany<PostComment>(x => x.Comments).WithOne(y => y.Post);
        }
    }
}
