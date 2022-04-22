using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Data.EF.Mappings.Comments;

public class ReactionMapping : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(a => a.CommentId).HasColumnType("varchar(36)").IsRequired();

        builder.OwnsOne(x => x.Author, author => author.Property(x => x.Id).HasColumnType("varchar(36)").HasColumnName("AuthorId").IsRequired());

        builder.Property(x => x.CommentReaction).HasColumnType("varchar(50)").HasConversion<string>().IsRequired();

        builder.ToTable("Reactions");
    }
}