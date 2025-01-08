using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class CommentDatabaseModelMapping : IEntityTypeConfiguration<CommentDatabaseModel>
{
    public void Configure(EntityTypeBuilder<CommentDatabaseModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.PostId).IsRequired();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.Content).HasMaxLength(PostConstants.MAX_COMMENT_BODY_LENGTH).IsUnicode().IsRequired();

        builder.Property(x => x.DateOfCreation).IsRequired();

        builder.Property(x => x.DateOfModification).IsRequired(false);

        builder.HasMany(x => x.Reactions).WithOne(x => x.Comment).HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Author).WithMany(x => x.Comments).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Comments");
    }
}