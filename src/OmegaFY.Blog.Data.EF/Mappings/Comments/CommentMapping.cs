using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Mappings.Comments;

public class CommentMapping : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.PostId).IsRequired();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.Body).HasMaxLength(PostConstants.MAX_COMMENT_BODY_LENGTH).IsUnicode().IsRequired();

        builder.ComplexProperty(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnName(nameof(ModificationDetails.DateOfCreation)).IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnName(nameof(ModificationDetails.DateOfModification)).IsRequired(false);
        });

        builder.HasMany(x => x.Reactions).WithOne().HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Comments");
    }
}