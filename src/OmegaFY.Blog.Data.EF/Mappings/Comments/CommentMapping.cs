using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Data.EF.Mappings.Comments;

public class CommentMapping : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.Body).HasColumnType($"varchar({PostConstants.MAX_COMMENT_BODY_LENGTH})").IsRequired();

        builder.OwnsOne(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnName("DateOfCreation").IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnName("DateOfModification").IsRequired(false);
        });

        builder.HasMany(x => x.Reactions).WithOne().HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Comments");
    }
}