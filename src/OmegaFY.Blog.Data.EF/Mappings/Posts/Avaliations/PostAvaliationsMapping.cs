using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts.Avaliations;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts.Avaliations;

public class PostAvaliationsMapping : IEntityTypeConfiguration<PostAvaliations>
{
    public void Configure(EntityTypeBuilder<PostAvaliations> builder)
    {
        builder.Property(x => x.AverageRate).IsRequired();

        builder.HasMany(x => x.Avaliations).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);
    }
}