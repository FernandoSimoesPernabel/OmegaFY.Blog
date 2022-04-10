using Microsoft.EntityFrameworkCore;

namespace OmegaFY.Blog.Data.EF.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
