using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts.Comments;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts.Comments;

public class CommentMapping : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(a => a.PostId).IsRequired();

        builder.OwnsOne(x => x.Author, author => author.Property(x => x.Id).HasColumnName("AuthorId").IsRequired());

        builder.OwnsOne(x => x.Body, body => body.Property(x => x.Content).HasColumnType("varchar(500)").HasColumnName("Content").IsRequired());

        builder.OwnsOne(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnType("datetime").HasColumnName("DateOfCreation").IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnType("datetime").HasColumnName("DateOfModification").IsRequired();
        });

        builder.HasMany(x => x.Reactions).WithOne().HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Comments");
    }
}