using MongoDB.Bson.Serialization;
using OmegaFY.Blog.Data.MongoDB.Serializers;
using OmegaFY.Blog.Data.MongoDB.Models;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace OmegaFY.Blog.Data.MongoDB.Context;

public static class MongoDbContext
{
    public static void RegisterSerializers()
    {
        BsonSerializer.RegisterSerializer(new HeaderSerializer());
        BsonSerializer.RegisterSerializer(new BodySerializer());
        BsonSerializer.RegisterSerializer(new ModificationDetailsSerializer());
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
    }

    public static void RegisterClassMaps()
    {
        if (BsonClassMap.IsClassMapRegistered(typeof(AvaliationCollectionModel)))
            return;

        BsonClassMap.RegisterClassMap<PostCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id);

            classMap.MapMember(map => map.AuthorId);

            classMap.MapMember(map => map.Title);

            classMap.MapMember(map => map.SubTitle);

            classMap.MapMember(map => map.Body);

            classMap.MapMember(map => map.DateOfCreation);

            classMap.MapMember(map => map.DateOfModification);

            classMap.MapMember(map => map.Private);

            classMap.MapMember(map => map.Avaliations);

            classMap.MapMember(map => map.Comments);

            classMap.MapMember(map => map.Shareds);
        });

        BsonClassMap.RegisterClassMap<AvaliationCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id);

            classMap.MapMember(map => map.PostId);

            classMap.MapMember(map => map.AuthorId);

            classMap.MapMember(map => map.DateOfCreation);

            classMap.MapMember(map => map.DateOfModification);
        });

        BsonClassMap.RegisterClassMap<PostAvaliationsCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.SetIgnoreExtraElements(true);

            classMap.MapIdMember(map => map.Id);

            classMap.MapMember(map => map.Avaliations);
        });

        BsonClassMap.RegisterClassMap<CommentCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id);

            classMap.MapMember(map => map.PostId);

            classMap.MapMember(map => map.AuthorId);

            classMap.MapMember(map => map.Body);

            classMap.MapMember(map => map.DateOfCreation);

            classMap.MapMember(map => map.DateOfModification);

            classMap.MapMember(map => map.Reactions);
        });

        BsonClassMap.RegisterClassMap<PostCommentsCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.SetIgnoreExtraElements(true);

            classMap.MapIdMember(map => map.Id);

            classMap.MapMember(map => map.Comments);
        });

        BsonClassMap.RegisterClassMap<ReactionCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id);

            classMap.MapMember(map => map.CommentId);

            classMap.MapMember(map => map.AuthorId);

            classMap.MapMember(map => map.CommentReaction);
        });

        BsonClassMap.RegisterClassMap<SharedCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id);

            classMap.MapMember(map => map.PostId);

            classMap.MapMember(map => map.AuthorId);

            classMap.MapMember(map => map.DateAndTimeOfShare);
        });

        BsonClassMap.RegisterClassMap<PostSharesCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.SetIgnoreExtraElements(true);

            classMap.MapIdMember(map => map.Id);

            classMap.MapMember(map => map.Shareds);
        });

        BsonClassMap.RegisterClassMap<UserCollectionModel>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapIdMember(map => map.Id);

            classMap.MapMember(map => map.Email);

            classMap.MapMember(map => map.DisplayName);
        });
    }
}