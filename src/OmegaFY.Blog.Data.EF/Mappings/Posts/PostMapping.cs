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

        builder.Property(x => x.Hidden).IsRequired();

        builder.OwnsOne(x => x.Author, author => author.Property(x => x.Id).HasColumnType("varchar(36)").HasColumnName("AuthorId").IsRequired());

        builder.OwnsOne(x => x.Body, body => body.Property(x => x.Content).HasColumnType("text").HasColumnName("Content").IsRequired());

        builder.OwnsOne(x => x.Header, header =>
        {
            header.Property(x => x.Title).HasColumnName("Title").HasColumnType($"varchar({PostConstants.MAX_TITLE_SIZE})").IsRequired();
            header.Property(x => x.SubTitle).HasColumnName("SubTitle").HasColumnType($"varchar({PostConstants.MAX_SUBTITLE_SIZE})").IsRequired();
        });

        builder.OwnsOne(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnType("datetime").HasColumnName("DateOfCreation").IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnType("datetime").HasColumnName("DateOfModification").IsRequired(false);
        });

        builder.ToTable("Posts");
    }
}