using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Mappings.Avaliations;

public class AvaliationMapping : IEntityTypeConfiguration<Avaliation>
{
    public void Configure(EntityTypeBuilder<Avaliation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.PostId).IsRequired();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.Rate).HasConversion<byte>().IsRequired();

        builder.ComplexProperty(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnName(nameof(ModificationDetails.DateOfCreation)).IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnName(nameof(ModificationDetails.DateOfModification)).IsRequired(false);
        });

        builder.ToTable("Avaliations");
    }
}