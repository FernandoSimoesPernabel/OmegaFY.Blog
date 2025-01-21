using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Common.Configs;
using OmegaFY.Blog.Data.EF.Authentication;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Interceptors;
using OmegaFY.Blog.Data.EF.QueryProviders;
using OmegaFY.Blog.Data.EF.Repositories;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Domain.Repositories.Comments;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Domain.Repositories.Users;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Data.EF.Extensions;

public static class EFServiceCollectionExtensions
{
    public static IServiceCollection AddSqliteEntityFrameworkContexts(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        return services.AddEntityFrameworkContexts(configuration.GetSqliteConnectionString(), DatabaseOptions.Sqlite, environment);
    }

    public static IServiceCollection AddSqlServerEntityFrameworkContexts(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        return services.AddEntityFrameworkContexts(configuration.GetSqlServerConnectionString(), DatabaseOptions.SqlServer, environment);
    }

    public static IServiceCollection AddEntityFrameworkContexts(
        this IServiceCollection services,
        string connectionString,
        DatabaseOptions database,
        IHostEnvironment environment)
    {
        Action<DbContextOptionsBuilder> allTrackingOptions = ConfigureDbContextOptionsBuilder(environment, connectionString, database);

        services.AddDbContextPool<AvaliationsContext>(allTrackingOptions);
        services.AddDbContextPool<CommentsContext>(allTrackingOptions);
        services.AddDbContextPool<DonationsContext>(allTrackingOptions);
        services.AddDbContextPool<PostsContext>(allTrackingOptions);
        services.AddDbContextPool<SharesContext>(allTrackingOptions);
        services.AddDbContextPool<UsersContext>(allTrackingOptions);

        services.AddDbContextPool<QueryContext>(ConfigureDbContextOptionsBuilder(environment, connectionString, database, QueryTrackingBehavior.NoTracking));

        return services;
    }

    public static IdentityBuilder AddEntityFrameworkStores(this IdentityBuilder identityBuilder)
    {
        return identityBuilder.AddEntityFrameworkStores<UsersContext>();
    }

    public static IServiceCollection AddEntityFrameworkUserManager(this IServiceCollection services)
    {
        services.AddScoped<IUserManager, EntityFrameworkUserManager>();

        return services;
    }

    public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IShareRepository, ShareRepository>();
        services.AddScoped<IAvaliationRepository, AvaliationRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        return services;
    }

    public static IServiceCollection AddEntityFrameworkQueryProviders(this IServiceCollection services)
    {
        services.AddScoped<IPostQueryProvider, PostQueryProvider>();
        services.AddScoped<IShareQueryProvider, ShareQueryProvider>();
        services.AddScoped<IAvaliationQueryProvider, AvaliationQueryProvider>();
        services.AddScoped<ICommentQueryProvider, CommentQueryProvider>();

        return services;
    }

    private static Action<DbContextOptionsBuilder> ConfigureDbContextOptionsBuilder(
        IHostEnvironment environment,
        string sqliteConnectionString,
        DatabaseOptions database,
        QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.TrackAll)
    {
        return options =>
        {
            if (database == DatabaseOptions.Sqlite)
                options.UseSqlite(sqliteConnectionString).UseQueryTrackingBehavior(trackingBehavior);

            if (database == DatabaseOptions.SqlServer)
                options.UseSqlServer(sqliteConnectionString).UseQueryTrackingBehavior(trackingBehavior);

            if (environment.IsDevelopment())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();

                options.AddInterceptors(
                    new CustomDbCommandInterceptor(),
                    new CustomDbConnectionInterceptor(),
                    new CustomDbTransactionInterceptor(),
                    new CustomSaveChangesInterceptor());
            }
        };
    }
}