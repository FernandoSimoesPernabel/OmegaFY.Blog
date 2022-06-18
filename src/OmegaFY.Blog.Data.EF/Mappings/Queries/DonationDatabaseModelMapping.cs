using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.Mappings.Queries;

public class DonationDatabaseModelMapping : IEntityTypeConfiguration<DonationDatabaseModel>
{
    public void Configure(EntityTypeBuilder<DonationDatabaseModel> builder)
    {

    }
}