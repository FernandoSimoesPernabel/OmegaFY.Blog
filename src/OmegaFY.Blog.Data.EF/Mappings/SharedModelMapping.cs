using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings;

public class SharedModelMapping : IEntityTypeConfiguration<SharedModel>
{
    public void Configure(EntityTypeBuilder<SharedModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.DateAndTimeOfShare).HasColumnType("datetime").IsRequired();

        builder.ToTable("Shares");
    }
}