﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class ReactionDatabaseModelMapping : IEntityTypeConfiguration<ReactionDatabaseModel>
{
    public void Configure(EntityTypeBuilder<ReactionDatabaseModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.CommentId).IsRequired();

        builder.Property(x => x.CommentReaction).HasMaxLength(50).IsUnicode(false).HasConversion<string>().IsRequired();

        builder.HasOne(x => x.Author).WithMany(x => x.Reactions).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Reactions");
    }
}