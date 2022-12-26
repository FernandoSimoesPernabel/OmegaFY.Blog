using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Mappings.Avaliations;
using OmegaFY.Blog.Data.EF.ValueConverts;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Data.EF.Context;

internal class AvaliationsContext : DbContext
{
    public AvaliationsContext(DbContextOptions<AvaliationsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostAvaliationsMapping());
        modelBuilder.ApplyConfiguration(new AvaliationMapping());

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<ReferenceId>().HaveConversion<ReferenceIdValueConverter>();
    }
}
