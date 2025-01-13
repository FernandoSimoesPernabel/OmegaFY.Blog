using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.ValueConverts;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Context;

internal class DonationsContext : DbContext
{
    public DonationsContext(DbContextOptions<DonationsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<ReferenceId>().HaveConversion<ReferenceIdValueConverter>();
    }
}
