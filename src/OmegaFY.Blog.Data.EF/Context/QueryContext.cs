using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Mappings.Queries;

namespace OmegaFY.Blog.Data.EF.Context;

internal class QueryContext : IdentityDbContext<IdentityUser>
{
    public QueryContext(DbContextOptions<QueryContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AvaliationDatabaseModelMapping());
        modelBuilder.ApplyConfiguration(new CommentDatabaseModelMapping());
        //modelBuilder.ApplyConfiguration(new DonationDatabaseModelMapping());
        modelBuilder.ApplyConfiguration(new PostDatabaseModelMapping());
        modelBuilder.ApplyConfiguration(new ReactionDatabaseModelMapping());
        modelBuilder.ApplyConfiguration(new SharedDatabaseModelMapping());
        modelBuilder.ApplyConfiguration(new UserDatabaseModelMapping());

        base.OnModelCreating(modelBuilder);
    }
}