using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Mappings.Comments;
using OmegaFY.Blog.Data.EF.ValueConverts;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Context;

internal class CommentsContext : DbContext
{
    public CommentsContext(DbContextOptions<CommentsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostCommentsMapping());
        modelBuilder.ApplyConfiguration(new CommentMapping());
        modelBuilder.ApplyConfiguration(new ReactionMapping());

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Body>().HaveConversion<BodyValueConverter>();
        configurationBuilder.Properties<ReferenceId>().HaveConversion<ReferenceIdValueConverter>();
    }
}
