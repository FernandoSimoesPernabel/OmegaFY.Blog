using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class SharedDatabaseModelMapping : IEntityTypeConfiguration<SharedDatabaseModel>
{
    public void Configure(EntityTypeBuilder<SharedDatabaseModel> builder)
    {

    }
}