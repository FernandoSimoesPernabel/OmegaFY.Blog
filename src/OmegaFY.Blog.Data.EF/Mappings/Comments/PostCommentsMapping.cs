using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Data.EF.Mappings.Comments;

public class PostCommentsMapping : IEntityTypeConfiguration<PostComments>
{
    public void Configure(EntityTypeBuilder<PostComments> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.HasMany(x => x.Comments).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Posts");
    }
}