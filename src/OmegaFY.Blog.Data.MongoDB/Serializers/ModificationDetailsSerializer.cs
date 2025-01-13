using MongoDB.Bson.Serialization;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Serializers;

internal class ModificationDetailsSerializer : StructSerializerBase<ModificationDetails>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ModificationDetails value)
    {
        context.Writer.WriteStartDocument();

        context.Writer.WriteDateTime("DateOfCreation", BsonUtils.ToMillisecondsSinceEpoch(value.DateOfCreation));

        if (value.DateOfModification.HasValue)
            context.Writer.WriteDateTime("DateOfModification", BsonUtils.ToMillisecondsSinceEpoch(value.DateOfModification.Value));
        else
            context.Writer.WriteNull("DateOfModification");

        context.Writer.WriteEndDocument();
    }

    public override ModificationDetails Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        context.Reader.ReadStartDocument();

        DateTime dateOfCreation = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(context.Reader.ReadDateTime("DateOfCreation"));

        DateTime? dateOfModification = null;

        if (context.Reader.FindElement("DateOfModification") && !context.Reader.IsAtEndOfFile())
            dateOfModification = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(context.Reader.ReadDateTime("DateOfModification"));

        context.Reader.ReadEndDocument();

        return new ModificationDetails(dateOfCreation, dateOfModification);
    }
}