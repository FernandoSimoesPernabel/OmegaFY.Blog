using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Mappings.Posts;
using OmegaFY.Blog.Data.EF.ValueConverts;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Context;

internal class PostsContext : DbContext
{
    public PostsContext(DbContextOptions<PostsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostMapping());

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Body>().HaveConversion<BodyValueConverter>();
        configurationBuilder.Properties<ReferenceId>().HaveConversion<ReferenceIdValueConverter>();
    }
}
