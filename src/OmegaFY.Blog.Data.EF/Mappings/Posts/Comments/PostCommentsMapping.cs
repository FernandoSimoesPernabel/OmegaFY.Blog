using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts.Comments;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts.Comments;

public class PostCommentsMapping : IEntityTypeConfiguration<PostComments>
{
    public void Configure(EntityTypeBuilder<PostComments> builder)
    {
        builder.HasMany(x => x.Comments).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);
    }
}