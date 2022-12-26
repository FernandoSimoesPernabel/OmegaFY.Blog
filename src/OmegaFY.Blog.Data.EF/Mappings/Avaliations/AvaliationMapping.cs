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

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").HasColumnName("AuthorId").IsRequired();

        builder.Property(x => x.Rate).HasConversion<byte>().IsRequired();

        builder.OwnsOne(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnName("DateOfCreation").IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnName("DateOfModification").IsRequired(false);
        });

        builder.ToTable("Avaliations");
    }
}