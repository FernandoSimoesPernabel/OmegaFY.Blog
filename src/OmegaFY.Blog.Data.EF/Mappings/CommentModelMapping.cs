using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings;

public class CommentModelMapping : IEntityTypeConfiguration<CommentModel>
{
    public void Configure(EntityTypeBuilder<CommentModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)");

        builder.Property(x => x.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.Content).HasColumnType("varchar(1000)").HasColumnName("Content").IsRequired();

        builder.Property(x => x.DateOfCreation).HasColumnType("datetime").IsRequired();

        builder.Property(x => x.DateOfModification).HasColumnType("datetime").IsRequired();

        builder.HasMany(x => x.Reactions).WithOne().HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Comments");
    }
}