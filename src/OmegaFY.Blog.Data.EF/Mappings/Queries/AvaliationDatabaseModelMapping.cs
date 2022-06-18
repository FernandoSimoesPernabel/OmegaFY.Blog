using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class AvaliationDatabaseModelMapping : IEntityTypeConfiguration<AvaliationDatabaseModel>
{
    public void Configure(EntityTypeBuilder<AvaliationDatabaseModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.Rate).HasConversion<byte>().IsRequired();

        builder.Property(x => x.DateOfCreation).HasColumnType("datetime").IsRequired();

        builder.Property(x => x.DateOfModification).HasColumnType("datetime").IsRequired(false);

        builder.HasOne(x => x.Author).WithMany(x => x.Avaliations).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Avaliations");
    }
}