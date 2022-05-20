using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Domain.QueryProviders.Posts.QueryResults;

namespace OmegaFY.Blog.Data.EF.Context;

internal class QueryContext : DbContext
{
    public QueryContext(DbContextOptions<QueryContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GetPostQueryResult>().HasNoKey();

        base.OnModelCreating(modelBuilder);
    }
}