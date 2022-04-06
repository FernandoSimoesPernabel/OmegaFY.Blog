using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts;

public class ReactionMapping : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(a => a.CommentId).IsRequired();

        builder.OwnsOne(x => x.Author, author => author.Property(x => x.Id).HasColumnName("AuthorId").IsRequired());

        builder.Property(x => x.CommentReaction).HasColumnType("varchar(50)").HasConversion<string>().IsRequired();
    }
}