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
    public static void RegisterClassMaps()
    {
        BsonClassMap.RegisterClassMap<Entity>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapMember(x => x.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.SetIsRootClass(true);
        });

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

        BsonClassMap.RegisterClassMap<User>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapMember(x => x.Email);

            classMap.MapMember(x => x.DisplayName);

            classMap.MapCreator(user => new User(user.Id, user.Email, user.DisplayName));
        });
    }

    public static void RegisterSerializers()
    {
        BsonSerializer.RegisterSerializer(new ReferenceIdSerializer());
        BsonSerializer.RegisterSerializer(new HeaderSerializer());
        BsonSerializer.RegisterSerializer(new BodySerializer());
        BsonSerializer.RegisterSerializer(new ModificationDetailsSerializer());
    }
}