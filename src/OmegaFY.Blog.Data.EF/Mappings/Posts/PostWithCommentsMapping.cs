using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts;

public class PostWithCommentsMapping : IEntityTypeConfiguration<PostWithComments>
{
    public void Configure(EntityTypeBuilder<PostWithComments> builder)
    {
        builder.HasMany(x => x.Comments).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);
    }
}