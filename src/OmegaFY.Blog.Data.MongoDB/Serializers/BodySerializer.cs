using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Data.MongoDB.Serializers;

internal class BodySerializer : StructSerializerBase<Body>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Body value)
        => context.Writer.WriteString(value.Content);

    public override Body Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        => new Body(context.Reader.ReadString());
}