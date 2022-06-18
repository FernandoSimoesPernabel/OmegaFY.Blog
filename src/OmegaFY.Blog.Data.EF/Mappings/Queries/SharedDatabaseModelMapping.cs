using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class SharedDatabaseModelMapping : IEntityTypeConfiguration<SharedDatabaseModel>
{
    public void Configure(EntityTypeBuilder<SharedDatabaseModel> builder)
    {
        builder.HasKey(x => new { x.PostId, x.AuthorId });

        builder.HasIndex(x => x.PostId);

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.DateAndTimeOfShare).HasColumnType("datetime").IsRequired();

        builder.ToTable("Shares");
    }
}