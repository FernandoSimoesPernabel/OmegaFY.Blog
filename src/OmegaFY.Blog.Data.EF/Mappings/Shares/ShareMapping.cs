using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Shares;

namespace OmegaFY.Blog.Data.EF.Mappings.Shares;

public class ShareMapping : IEntityTypeConfiguration<Shared>
{
    public void Configure(EntityTypeBuilder<Shared> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.HasIndex(x => x.PostId);

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.DateAndTimeOfShare).IsRequired();

        builder.ToTable("Shares");
    }
}