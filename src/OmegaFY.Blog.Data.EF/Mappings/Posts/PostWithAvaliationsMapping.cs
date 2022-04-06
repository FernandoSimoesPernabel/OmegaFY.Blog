using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts;

public class PostWithAvaliationsMapping : IEntityTypeConfiguration<PostWithAvaliations>
{
    public void Configure(EntityTypeBuilder<PostWithAvaliations> builder)
    {
        builder.Property(x => x.AverageRate).IsRequired();

        builder.HasMany(x => x.Avaliations).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);
    }
}