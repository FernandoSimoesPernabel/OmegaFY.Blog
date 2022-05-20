using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories;
using OmegaFY.Blog.Domain.Repositories.Posts;

namespace OmegaFY.Blog.Data.EF.Extensions;

public static class EFServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkContexts(this IServiceCollection services, IConfiguration configuration)
    {
        string sqlLiteConnectionString = configuration.GetConnectionString("SqlLite");

        services.AddDbContextPool<AvaliationsContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<CommentsContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<DonationsContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<PostsContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<SharesContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<UsersContext>(options => options.UseSqlite(sqlLiteConnectionString));

        return services;
    }

    public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();

        return services;
    }
}
