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

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.Private).IsRequired();

        builder.Property(x => x.Content).HasColumnType("text").IsRequired();

        builder.Property(x => x.Title).HasColumnType($"varchar({PostConstants.MAX_TITLE_LENGTH})").IsRequired();

        builder.Property(x => x.SubTitle).HasColumnType($"varchar({PostConstants.MAX_SUBTITLE_LENGTH})").IsRequired();

        builder.Property(x => x.DateOfCreation).HasColumnType("datetime").IsRequired();

        builder.Property(x => x.DateOfModification).HasColumnType("datetime").IsRequired(false);

        builder.Property(x => x.AverageRate).HasColumnType("numeric").IsRequired().HasDefaultValue(0);

        builder.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Avaliations).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Comments).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Shareds).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Posts");
    }
}