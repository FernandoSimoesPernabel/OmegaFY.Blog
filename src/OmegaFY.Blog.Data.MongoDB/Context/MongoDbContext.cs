using MongoDB.Bson.Serialization;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Entities;
using OmegaFY.Blog.Data.MongoDB.Serializers;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Entities.Shares;

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