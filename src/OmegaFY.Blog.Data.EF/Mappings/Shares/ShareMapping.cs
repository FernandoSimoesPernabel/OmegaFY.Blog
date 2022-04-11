using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Shares;

namespace OmegaFY.Blog.Data.EF.Mappings.Shares;

public class ShareMapping : IEntityTypeConfiguration<Shared>
{
    public void Configure(EntityTypeBuilder<Shared> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(a => a.PostId).HasColumnType("varchar(36)").IsRequired();

        builder.OwnsOne(x => x.Author, author => author.Property(x => x.Id).HasColumnType("varchar(36)").HasColumnName("AuthorId").IsRequired());

        builder.Property(x => x.DateAndTimeOfShare).HasColumnType("datetime").IsRequired();

        builder.ToTable("Shares");
    }
}