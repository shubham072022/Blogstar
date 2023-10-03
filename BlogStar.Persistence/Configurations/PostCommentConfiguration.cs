using BlogStar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogStar.Persistence.Configurations
{
    public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder) 
        {
            builder.Property(x => x.Comment).IsRequired().HasMaxLength(500);
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne<Post>(x => x.Post).WithMany(y => y.Comments);
        }
    }
}
