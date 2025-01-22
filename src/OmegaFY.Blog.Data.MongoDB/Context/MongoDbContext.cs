using MongoDB.Bson.Serialization;
using OmegaFY.Blog.Data.MongoDB.Serializers;
using MongoDB.Bson.Serialization.Serializers;
using OmegaFY.Blog.Data.MongoDB.Models;

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
        if (BsonClassMap.IsClassMapRegistered(typeof(AvaliationCollectionModel)))
            return;

        BsonClassMap.RegisterClassMap<AvaliationCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.PostId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.AuthorId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.ModificationDetails).SetSerializer(new ModificationDetailsSerializer());
        });

        BsonClassMap.RegisterClassMap<PostAvaliationsCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.SetIgnoreExtraElements(true);

            classMap.MapIdMember(map => map.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.Avaliations);
        });

        BsonClassMap.RegisterClassMap<CommentCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.PostId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.AuthorId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.Body).SetSerializer(new BodySerializer());

            classMap.MapMember(map => map.ModificationDetails).SetSerializer(new ModificationDetailsSerializer());

            classMap.MapMember(map => map.Reactions);
        });

        BsonClassMap.RegisterClassMap<PostCommentsCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.Comments);
        });

        BsonClassMap.RegisterClassMap<PostCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.AuthorId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.Header).SetSerializer(new HeaderSerializer());

            classMap.MapMember(map => map.Body).SetSerializer(new BodySerializer());

            classMap.MapMember(map => map.ModificationDetails).SetSerializer(new ModificationDetailsSerializer());

            classMap.MapMember(map => map.Private);
        });

        BsonClassMap.RegisterClassMap<ReactionCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.CommentId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.AuthorId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.CommentReaction);
        });

        BsonClassMap.RegisterClassMap<SharedCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.PostId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.AuthorId).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.DateAndTimeOfShare);
        });

        BsonClassMap.RegisterClassMap<PostSharesCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.Shareds);
        });

        BsonClassMap.RegisterClassMap<UserCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id).SetSerializer(new ReferenceIdSerializer());

            classMap.MapMember(map => map.Email);

            classMap.MapMember(map => map.DisplayName);
        });
    }
}