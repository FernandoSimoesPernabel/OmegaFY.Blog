using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Avaliations;

namespace OmegaFY.Blog.Data.EF.Mappings.Avaliations;

public class PostAvaliationsMapping : IEntityTypeConfiguration<PostAvaliations>
{
    public void Configure(EntityTypeBuilder<PostAvaliations> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.AverageRate).IsRequired();

        builder.HasMany(x => x.Avaliations).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Posts");
    }
}