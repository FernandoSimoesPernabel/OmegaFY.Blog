using MongoDB.Bson.Serialization;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Entities;
using OmegaFY.Blog.Data.MongoDB.Serializers;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Entities.Users;

namespace OmegaFY.Blog.Data.MongoDB.Context;

public static class MongoDbContext
{
    public static void RegisterSerializers()
    {
        BsonSerializer.RegisterSerializer(new ReferenceIdSerializer());
        BsonSerializer.RegisterSerializer(new HeaderSerializer());
        BsonSerializer.RegisterSerializer(new BodySerializer());
        BsonSerializer.RegisterSerializer(new ModificationDetailsSerializer());
    }

    public static void RegisterClassMaps()
    {
        RegisterEntityClassMap();

        RegisterPostClassMap();

        RegisterPostAvaliationsClassMap();

        RegisterAvaliationClassMap();

        RegisterPostCommentsClassMap();

        RegisterCommentClassMap();

        RegisterReactionClassMap();

        RegisterPostSharesReactionClass();

        RegisterSharedClassMap();

        RegisterUserClassMap();
    }

    private static void RegisterUserClassMap()
    {
        BsonClassMap.RegisterClassMap<User>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapMember(x => x.Email);

            classMap.MapMember(x => x.DisplayName);

            classMap.MapCreator(user => new User(user.Id, user.Email, user.DisplayName));
        });
    }

    private static void RegisterSharedClassMap()
    {
        BsonClassMap.RegisterClassMap<Shared>(classMap =>
        {
            classMap.AutoMap();


        });
    }

    private static void RegisterPostSharesReactionClass()
    {
        BsonClassMap.RegisterClassMap<PostShares>(classMap =>
        {
            classMap.AutoMap();


        });
    }

    private static void RegisterReactionClassMap()
    {
        BsonClassMap.RegisterClassMap<Reaction>(classMap =>
        {
            classMap.AutoMap();


        });
    }

    private static void RegisterCommentClassMap()
    {
        BsonClassMap.RegisterClassMap<Comment>(classMap =>
        {
            classMap.AutoMap();


        });
    }

    private static void RegisterPostCommentsClassMap()
    {
        BsonClassMap.RegisterClassMap<PostComments>(classMap =>
        {
            classMap.AutoMap();


        });
    }

    private static void RegisterAvaliationClassMap()
    {
        BsonClassMap.RegisterClassMap<Avaliation>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapMember(x => x.PostId);

            classMap.MapMember(x => x.AuthorId);

            classMap.MapMember(x => x.ModificationDetails);

            classMap.MapMember(x => x.Rate);

            classMap.MapCreator(avaliation => new Avaliation(avaliation.Id, avaliation.PostId, avaliation.AuthorId, avaliation.Rate));
        });
    }

    private static void RegisterPostAvaliationsClassMap()
    {
        BsonClassMap.RegisterClassMap<PostAvaliations>(classMap =>
        {
            classMap.AutoMap();

            classMap.SetIgnoreExtraElements(true);

            classMap.MapMember(x => x.Avaliations);

            classMap.MapMember(x => x.AverageRate);

            classMap.MapCreator(post => new PostAvaliations(post.Id, post.Avaliations, post.AverageRate));
        });
    }

    private static void RegisterPostClassMap()
    {
        BsonClassMap.RegisterClassMap<Post>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapMember(x => x.AuthorId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(x => x.Header).SetSerializer(new HeaderSerializer());

            classMap.MapMember(x => x.Body).SetSerializer(new BodySerializer());

            classMap.MapMember(x => x.ModificationDetails).SetSerializer(new ModificationDetailsSerializer());

            classMap.MapMember(x => x.Private);

            classMap.MapCreator(post => new Post(post.Id, post.AuthorId, post.Header, post.Body, post.ModificationDetails, post.Private));
        });
    }

    private static void RegisterEntityClassMap()
    {
        BsonClassMap.RegisterClassMap<Entity>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapMember(x => x.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.SetIsRootClass(true);
        });
    }
}