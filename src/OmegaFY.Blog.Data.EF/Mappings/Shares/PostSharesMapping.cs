﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Shares;

namespace OmegaFY.Blog.Data.EF.Mappings.Shares;

public class PostSharesMapping : IEntityTypeConfiguration<PostShares>
{
    public void Configure(EntityTypeBuilder<PostShares> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("varchar(36)").IsRequired();

        builder.HasMany(x => x.Shareds).WithOne().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Posts");
    }
}