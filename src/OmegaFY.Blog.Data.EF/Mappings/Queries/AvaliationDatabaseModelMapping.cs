using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class AvaliationDatabaseModelMapping : IEntityTypeConfiguration<AvaliationDatabaseModel>
{
    public void Configure(EntityTypeBuilder<AvaliationDatabaseModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.PostId).IsRequired();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.Rate).HasConversion<byte>().IsUnicode(false).IsRequired();

        builder.Property(x => x.DateOfCreation).IsRequired();

        builder.Property(x => x.DateOfModification).IsRequired(false);

        builder.HasOne(x => x.Post).WithMany(x => x.Avaliations).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Author).WithMany(x => x.Avaliations).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Avaliations");
    }
}