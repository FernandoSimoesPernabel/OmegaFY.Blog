﻿using Microsoft.EntityFrameworkCore;
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

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired().ValueGeneratedNever();

        builder.Property(x => x.Email).HasColumnType($"varchar({UserConstants.MAX_EMAIL_LENGTH})").IsRequired();

        builder.Property(x => x.DisplayName).HasColumnType($"varchar({UserConstants.MAX_DISPLAY_NAME_LENGTH})").IsRequired();

        builder.ToTable("Users");
    }
}