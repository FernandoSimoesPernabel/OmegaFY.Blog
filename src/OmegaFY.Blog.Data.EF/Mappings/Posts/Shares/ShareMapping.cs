using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Posts.Shares;

namespace OmegaFY.Blog.Data.EF.Mappings.Posts.Shares;

public class ShareMapping : IEntityTypeConfiguration<Shared>
{
    public void Configure(EntityTypeBuilder<Shared> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(a => a.PostId).IsRequired();

        builder.OwnsOne(x => x.Author, author => author.Property(x => x.Id).HasColumnName("AuthorId").IsRequired());

        builder.Property(x => x.DateAndTimeOfShare).HasColumnType("datetime").IsRequired();

        builder.ToTable("Shares");
    }
}