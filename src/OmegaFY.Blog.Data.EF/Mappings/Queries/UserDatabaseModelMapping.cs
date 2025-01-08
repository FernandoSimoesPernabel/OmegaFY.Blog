using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;
using OmegaFY.Blog.Domain.Constantes;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class UserDatabaseModelMapping : IEntityTypeConfiguration<UserDatabaseModel>
{
    public void Configure(EntityTypeBuilder<UserDatabaseModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.Email).HasMaxLength(UserConstants.MAX_EMAIL_LENGTH).IsUnicode(false).IsRequired();

        builder.Property(x => x.DisplayName).HasMaxLength(UserConstants.MAX_DISPLAY_NAME_LENGTH).IsUnicode(false).IsRequired();

        builder.ToTable("Users");
    }
}