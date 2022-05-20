using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Mappings.Shares;

namespace OmegaFY.Blog.Data.EF.Context;

internal class SharesContext : DbContext
{
    public SharesContext(DbContextOptions<SharesContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostSharesMapping());
        modelBuilder.ApplyConfiguration(new ShareMapping());

        base.OnModelCreating(modelBuilder);
    }
}