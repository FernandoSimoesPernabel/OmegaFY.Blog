using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Data.EF.Mappings.Comments;

public class ReactionMapping : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.CommentId).IsRequired();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.CommentReaction).HasMaxLength(50).HasConversion<string>().IsUnicode(false).IsRequired();

        builder.ToTable("Reactions");
    }
}