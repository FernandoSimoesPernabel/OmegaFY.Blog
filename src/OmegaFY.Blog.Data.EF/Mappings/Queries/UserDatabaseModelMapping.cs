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

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.Email).HasColumnType($"varchar({UserConstants.MAX_EMAIL_LENGTH})").IsRequired();

        builder.Property(x => x.DisplayName).HasColumnType($"varchar({UserConstants.MAX_DISPLAY_NAME_LENGTH})").IsRequired();

        builder.ToTable("Users");
    }
}