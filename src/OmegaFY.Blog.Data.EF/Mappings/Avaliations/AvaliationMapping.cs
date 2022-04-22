using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Avaliations;

namespace OmegaFY.Blog.Data.EF.Mappings.Avaliations;

public class AvaliationMapping : IEntityTypeConfiguration<Avaliation>
{
    public void Configure(EntityTypeBuilder<Avaliation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(a => a.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.OwnsOne(x => x.Author, author => author.Property(x => x.Id).HasColumnType("varchar(36)").HasColumnName("AuthorId").IsRequired());

        builder.Property(x => x.Rate).HasConversion<byte>().IsRequired();

        builder.OwnsOne(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnType("datetime").HasColumnName("DateOfCreation").IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnType("datetime").HasColumnName("DateOfModification").IsRequired();
        });

        builder.ToTable("Avaliations");
    }
}