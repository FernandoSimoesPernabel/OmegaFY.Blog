using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Data.MongoDB.Authentication;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Context;
using OmegaFY.Blog.Data.MongoDB.QueryProviders;
using OmegaFY.Blog.Data.MongoDB.Repositories;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Domain.Repositories.Comments;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Domain.Repositories.Users;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class MongoDbServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        MongoDbContext.RegisterSerializers();
        MongoDbContext.RegisterClassMaps();

        MongoClient mongoClient = new MongoClient(configuration.GetMongoDbConnectionString());

        services.AddSingleton<IMongoClient>(mongoClient);

        services.AddSingleton(mongoClient.GetDatabase(MongoDbContants.DATABASE_NAME));

        return services;
    }

    public static IdentityBuilder AddMongoDbIdentityUserConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetMongoDbConnectionString();

        return services.AddIdentityMongoDbProvider<MongoUser<string>, MongoRole<string>, string>(mongo => mongo.ConnectionString = connectionString);
    }

    public static IServiceCollection AddMongoDbUserManager(this IServiceCollection services)
    {
        services.AddScoped<IUserManager, MongoDbUserManager>();

        return services;
    }

    public static IServiceCollection AddMongoDbRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IShareRepository, ShareRepository>();
        services.AddScoped<IAvaliationRepository, AvaliationRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        return services;
    }

    public static IServiceCollection AddMongoDbQueryProviders(this IServiceCollection services)
    {
        services.AddScoped<IPostQueryProvider, PostQueryProvider>();
        services.AddScoped<IShareQueryProvider, ShareQueryProvider>();
        services.AddScoped<IAvaliationQueryProvider, AvaliationQueryProvider>();
        services.AddScoped<ICommentQueryProvider, CommentQueryProvider>();

        return services;
    }
}