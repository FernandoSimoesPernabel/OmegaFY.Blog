using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.QueryProviders;
using OmegaFY.Blog.Data.EF.Repositories;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Domain.Repositories.Users;

namespace OmegaFY.Blog.Data.EF.Extensions;

public static class EFServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkContexts(this IServiceCollection services, IConfiguration configuration)
    {
        string sqlLiteConnectionString = configuration.GetSqlLiteConnectionString();

        services.AddDbContextPool<AvaliationsContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<CommentsContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<DonationsContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<PostsContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<SharesContext>(options => options.UseSqlite(sqlLiteConnectionString));
        services.AddDbContextPool<UsersContext>(options => options.UseSqlite(sqlLiteConnectionString));

        services.AddDbContextPool<QueryContext>(options => options.UseSqlite(sqlLiteConnectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        return services;
    }

    public static IdentityBuilder AddEntityFrameworkIdentityUserConfiguration(this IdentityBuilder identityBuilder)
    {
        identityBuilder.AddEntityFrameworkStores<UsersContext>().AddDefaultTokenProviders();

        return identityBuilder;
    }

    public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IShareRepository, ShareRepository>();

        return services;
    }

    public static IServiceCollection AddEntityFrameworkQueryProviders(this IServiceCollection services)
    {
        services.AddScoped<IPostQueryProvider, PostQueryProvider>();
        services.AddScoped<IShareQueryProvider, ShareQueryProvider>();

        return services;
    }
}