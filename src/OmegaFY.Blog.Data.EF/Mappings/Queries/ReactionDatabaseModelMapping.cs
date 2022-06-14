using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class ReactionDatabaseModelMapping : IEntityTypeConfiguration<ReactionDatabaseModel>
{
    public void Configure(EntityTypeBuilder<ReactionDatabaseModel> builder)
    {

    }
}