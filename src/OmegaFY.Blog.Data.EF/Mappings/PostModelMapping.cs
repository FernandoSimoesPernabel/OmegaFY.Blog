using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts;

public class PostModelMapping : IEntityTypeConfiguration<PostModel>
{
    public void Configure(EntityTypeBuilder<PostModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.AuthorId).HasColumnType("varchar(36)").IsRequired();

        builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(50)").IsRequired();

        builder.Property(x => x.SubTitle).HasColumnName("SubTitle").HasColumnType("varchar(50)").IsRequired();

        builder.Property(x => x.Content).HasColumnType("varchar(1000)").HasColumnName("Content").IsRequired();

        builder.Property(x => x.DateOfCreation).HasColumnType("datetime").IsRequired();
        
        builder.Property(x => x.DateOfModification).HasColumnType("datetime").IsRequired();

        builder.Property(x => x.AverageRate).IsRequired();

        builder.HasMany(x => x.Avaliations).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Comments).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Shareds).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Posts");
    }
}
