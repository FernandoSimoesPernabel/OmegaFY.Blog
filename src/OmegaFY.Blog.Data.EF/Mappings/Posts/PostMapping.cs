using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Author, author => author.Property(x => x.Id).HasColumnName("AuthorId").IsRequired());

        builder.OwnsOne(x => x.Body, body => body.Property(x => x.Content).HasColumnType("varchar(max)").HasColumnName("Content").IsRequired());

        builder.OwnsOne(x => x.Header, header =>
        {
            header.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(50)").IsRequired();
            header.Property(x => x.SubTitle).HasColumnName("SubTitle").HasColumnType("varchar(50)").IsRequired();
        });

        builder.OwnsOne(x => x.ModificationDetails, modificationDetails =>
        {
            modificationDetails.Property(x => x.DateOfCreation).HasColumnType("datetime").HasColumnName("DateOfCreation").IsRequired();
            modificationDetails.Property(x => x.DateOfModification).HasColumnType("datetime").HasColumnName("DateOfModification").IsRequired();
        });

        builder.ToTable("Posts");
    }
}