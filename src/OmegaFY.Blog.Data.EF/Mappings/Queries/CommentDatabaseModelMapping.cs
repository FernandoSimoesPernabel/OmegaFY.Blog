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

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.Content).HasColumnType($"varchar({PostConstants.MAX_COMMENT_BODY_LENGTH})").IsRequired();

        builder.Property(x => x.DateOfCreation).HasColumnType("datetime").IsRequired();

        builder.Property(x => x.DateOfModification).HasColumnType("datetime").IsRequired(false);

        builder.HasMany(x => x.Reactions).WithOne().HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Author).WithMany(x => x.Comments).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Comments");
    }
}