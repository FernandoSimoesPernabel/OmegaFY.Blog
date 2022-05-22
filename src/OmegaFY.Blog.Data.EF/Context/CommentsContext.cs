using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Mappings.Comments;

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
}
