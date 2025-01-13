using MongoDB.Bson.Serialization;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Serializers;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Data.MongoDB.Serializers;

internal class HeaderSerializer : StructSerializerBase<Header>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Header value)
    {
        context.Writer.WriteStartDocument();

        context.Writer.WriteString(nameof(Header.Title), value.Title);

        context.Writer.WriteString(nameof(Header.SubTitle), value.SubTitle);

        context.Writer.WriteEndDocument();
    }

    public override Header Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        => new Header(context.Reader.ReadString(nameof(Header.Title)), context.Reader.ReadString(nameof(Header.SubTitle)));
}