using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class PostDatabaseModelMapping : IEntityTypeConfiguration<PostDatabaseModel>
{
    public void Configure(EntityTypeBuilder<PostDatabaseModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.Private).IsRequired();

        builder.Property(x => x.Content).IsUnicode().IsRequired();

        builder.Property(x => x.Title).HasMaxLength(PostConstants.MAX_TITLE_LENGTH).IsUnicode(false).IsRequired();

        builder.Property(x => x.SubTitle).HasMaxLength(PostConstants.MAX_SUBTITLE_LENGTH).IsUnicode(false).IsRequired();

        builder.Property(x => x.DateOfCreation).IsRequired();

        builder.Property(x => x.DateOfModification).IsRequired(false);

        builder.Property(x => x.AverageRate).IsRequired().HasDefaultValue(0);

        builder.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Avaliations).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Shareds).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Posts");
    }
}