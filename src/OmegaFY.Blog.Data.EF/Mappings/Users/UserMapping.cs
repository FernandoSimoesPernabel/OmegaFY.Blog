using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Entities.Users;

namespace OmegaFY.Blog.Data.EF.Mappings.Users;

internal class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.Email).HasMaxLength(UserConstants.MAX_EMAIL_LENGTH).IsUnicode(false).IsRequired();

        builder.Property(x => x.DisplayName).HasMaxLength(UserConstants.MAX_DISPLAY_NAME_LENGTH).IsUnicode(false).IsUnicode(false).IsRequired();

        builder.ToTable("Users");
    }
}