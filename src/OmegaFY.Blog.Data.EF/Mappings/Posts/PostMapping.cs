using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.Private).IsRequired();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.Body).IsUnicode().HasColumnName("Content").IsRequired();

        builder.OwnsOne(x => x.Header, header =>
        {
            header.Property(x => x.Title).HasColumnName(nameof(Header.Title)).HasMaxLength(PostConstants.MAX_TITLE_LENGTH).IsUnicode(false).IsRequired();
            header.Property(x => x.SubTitle).HasColumnName(nameof(Header.SubTitle)).HasMaxLength(PostConstants.MAX_SUBTITLE_LENGTH).IsUnicode(false).IsRequired();
        });

        builder.OwnsOne(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnName(nameof(ModificationDetails.DateOfCreation)).IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnName(nameof(ModificationDetails.DateOfModification)).IsRequired(false);
        });

        builder.ToTable("Posts");
    }
}