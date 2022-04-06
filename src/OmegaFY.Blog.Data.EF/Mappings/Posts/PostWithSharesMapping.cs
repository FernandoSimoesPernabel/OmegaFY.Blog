using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts;

public class PostWithSharesMapping : IEntityTypeConfiguration<PostWithShares>
{
    public void Configure(EntityTypeBuilder<PostWithShares> builder)
    {
        builder.HasMany(x => x.Shareds).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);
    }
}