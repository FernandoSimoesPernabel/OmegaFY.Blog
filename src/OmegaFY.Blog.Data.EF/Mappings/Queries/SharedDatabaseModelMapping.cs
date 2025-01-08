using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class SharedDatabaseModelMapping : IEntityTypeConfiguration<SharedDatabaseModel>
{
    public void Configure(EntityTypeBuilder<SharedDatabaseModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.HasIndex(x => x.PostId);

        builder.Property(x => x.PostId).IsRequired();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.DateAndTimeOfShare).IsRequired();

        builder.HasOne(x => x.Author).WithMany(x => x.Shareds).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Post).WithMany(x => x.Shareds).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Shares");
    }
}