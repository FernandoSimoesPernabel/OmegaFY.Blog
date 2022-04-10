using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Mappings.Posts;

namespace OmegaFY.Blog.Data.EF.Context;

public class PostsContext : DbContext
{
    public PostsContext(DbContextOptions<PostsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostMapping());

        base.OnModelCreating(modelBuilder);
    }
}
