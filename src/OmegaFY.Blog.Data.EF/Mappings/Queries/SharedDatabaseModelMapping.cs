using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class SharedDatabaseModelMapping : IEntityTypeConfiguration<SharedDatabaseModel>
{
    public void Configure(EntityTypeBuilder<SharedDatabaseModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.HasIndex(x => x.PostId);

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.DateAndTimeOfShare).HasColumnType("datetime").IsRequired();

        builder.HasOne(x => x.Author).WithMany(x => x.Shareds).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Shares");
    }
}