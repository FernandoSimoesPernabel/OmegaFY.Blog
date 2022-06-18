using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class ReactionDatabaseModelMapping : IEntityTypeConfiguration<ReactionDatabaseModel>
{
    public void Configure(EntityTypeBuilder<ReactionDatabaseModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.CommentId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.CommentReaction).HasColumnType("varchar(50)").HasConversion<string>().IsRequired();

        builder.ToTable("Reactions");
    }
}