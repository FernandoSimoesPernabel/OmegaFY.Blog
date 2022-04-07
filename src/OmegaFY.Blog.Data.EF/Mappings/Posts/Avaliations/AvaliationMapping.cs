using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts.Avaliations;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts.Avaliations;

public class AvaliationMapping : IEntityTypeConfiguration<Avaliation>
{
    public void Configure(EntityTypeBuilder<Avaliation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(a => a.PostId).IsRequired();

        builder.OwnsOne(x => x.Author, author => author.Property(x => x.Id).HasColumnName("AuthorId").IsRequired());

        builder.Property(x => x.Rate).HasConversion<byte>().IsRequired();

        builder.OwnsOne(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnType("datetime").HasColumnName("DateOfCreation").IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnType("datetime").HasColumnName("DateOfModification").IsRequired();
        });

        builder.ToTable("Avaliations");
    }
}