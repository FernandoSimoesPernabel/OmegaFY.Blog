using Microsoft.EntityFrameworkCore;

namespace OmegaFY.Blog.Data.EF.Context;

public class DonationsContext : DbContext
{
    public DonationsContext(DbContextOptions<DonationsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
