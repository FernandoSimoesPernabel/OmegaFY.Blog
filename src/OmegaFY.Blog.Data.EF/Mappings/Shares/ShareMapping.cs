using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Data.EF.Mappings.Shares;

public class ShareMapping : IEntityTypeConfiguration<Shared>
{
    public void Configure(EntityTypeBuilder<Shared> builder)
    {
        builder.HasKey(x => new { x.PostId, x.AuthorId });

        builder.HasIndex(x => x.PostId);

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.DateAndTimeOfShare).IsRequired();

        builder.ToTable("Shares");
    }
}