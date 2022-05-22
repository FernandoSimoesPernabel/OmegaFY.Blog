using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;

namespace OmegaFY.Blog.Data.EF.Context;

internal class QueryContext : DbContext
{
    public QueryContext(DbContextOptions<QueryContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GetPostQueryResult>().HasNoKey();
        modelBuilder.Entity<GetAllPostsQueryResult>().HasNoKey();

        base.OnModelCreating(modelBuilder);
    }
}