using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings;

public class AvaliationModelMapping : IEntityTypeConfiguration<AvaliationModel>
{
    public void Configure(EntityTypeBuilder<AvaliationModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)");

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.Rate).HasConversion<byte>().IsRequired();

        builder.Property(x => x.DateOfCreation).HasColumnType("datetime").IsRequired();

        builder.Property(x => x.DateOfModification).HasColumnType("datetime").IsRequired();

        builder.ToTable("Avaliations");
    }
}