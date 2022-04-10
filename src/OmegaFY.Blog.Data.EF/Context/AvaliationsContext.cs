using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Mappings.Avaliations;

namespace OmegaFY.Blog.Data.EF.Context;

public class AvaliationsContext : DbContext
{
    public AvaliationsContext(DbContextOptions<AvaliationsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostAvaliationsMapping());
        modelBuilder.ApplyConfiguration(new AvaliationMapping());

        base.OnModelCreating(modelBuilder);
    }
}
