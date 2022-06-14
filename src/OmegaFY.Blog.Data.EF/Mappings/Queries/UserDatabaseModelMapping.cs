using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class UserDatabaseModelMapping : IEntityTypeConfiguration<UserDatabaseModel>
{
    public void Configure(EntityTypeBuilder<UserDatabaseModel> builder)
    {

    }
}