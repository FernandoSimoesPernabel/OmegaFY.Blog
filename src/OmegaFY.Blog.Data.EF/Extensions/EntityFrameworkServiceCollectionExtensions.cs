using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.QueryProviders;
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

        services.AddDbContextPool<QueryContext>(options => options.UseSqlite(sqlLiteConnectionString));

        return services;
    }

    public static IServiceCollection AddIdentityUserConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UsersContext>().AddDefaultTokenProviders();

        return services;
    }

    public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();

        return services;
    }

    public static IServiceCollection AddEntityFrameworkQueryProviders(this IServiceCollection services)
    {
        services.AddScoped<IPostQueryProvider, PostQueryProvider>();

        return services;
    }
}
