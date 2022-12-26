using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;
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
    public static IServiceCollection AddEntityFrameworkContexts(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        string sqlLiteConnectionString = configuration.GetSqlLiteConnectionString();

        services.AddDbContextPool<AvaliationsContext>(ConfigureSqlLiteOptions(environment, sqlLiteConnectionString));
        services.AddDbContextPool<CommentsContext>(ConfigureSqlLiteOptions(environment, sqlLiteConnectionString));
        services.AddDbContextPool<DonationsContext>(ConfigureSqlLiteOptions(environment, sqlLiteConnectionString));
        services.AddDbContextPool<PostsContext>(ConfigureSqlLiteOptions(environment, sqlLiteConnectionString));
        services.AddDbContextPool<SharesContext>(ConfigureSqlLiteOptions(environment, sqlLiteConnectionString));
        services.AddDbContextPool<UsersContext>(ConfigureSqlLiteOptions(environment, sqlLiteConnectionString));

        services.AddDbContextPool<QueryContext>(ConfigureSqlLiteOptions(environment, sqlLiteConnectionString, QueryTrackingBehavior.NoTracking));

        return services;
    }

    private static Action<DbContextOptionsBuilder> ConfigureSqlLiteOptions(
        IHostEnvironment environment,
        string sqlLiteConnectionString,
        QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.TrackAll)
    {
        return options =>
        {
            options.UseSqlite(sqlLiteConnectionString).UseQueryTrackingBehavior(trackingBehavior);

            if (environment.IsDevelopment())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }
        };
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
        services.AddScoped<IAvaliationQueryProvider, AvaliationQueryProvider>();

        return services;
    }
}