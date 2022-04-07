using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts.Shares;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts.Shares;

public class PostSharesMapping : IEntityTypeConfiguration<PostShares>
{
    public void Configure(EntityTypeBuilder<PostShares> builder)
    {
        builder.HasMany(x => x.Shareds).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);
    }
}