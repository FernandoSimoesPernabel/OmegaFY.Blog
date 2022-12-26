using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.Private).IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.Body).HasColumnType("text").HasColumnName("Content").IsRequired();

        builder.OwnsOne(x => x.Header, header =>
        {
            header.Property(x => x.Title).HasColumnName("Title").HasColumnType($"varchar({PostConstants.MAX_TITLE_LENGTH})").IsRequired();
            header.Property(x => x.SubTitle).HasColumnName("SubTitle").HasColumnType($"varchar({PostConstants.MAX_SUBTITLE_LENGTH})").IsRequired();
        });

        builder.OwnsOne(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnName("DateOfCreation").IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnName("DateOfModification").IsRequired(false);
        });

        builder.ToTable("Posts");
    }
}