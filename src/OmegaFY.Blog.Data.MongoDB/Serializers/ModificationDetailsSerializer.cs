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

        context.Writer.WriteDateTime(nameof(ModificationDetails.DateOfCreation), BsonUtils.ToMillisecondsSinceEpoch(value.DateOfCreation));

        if (value.DateOfModification.HasValue)
            context.Writer.WriteDateTime(nameof(ModificationDetails.DateOfModification), BsonUtils.ToMillisecondsSinceEpoch(value.DateOfModification.Value));
        else
            context.Writer.WriteNull(nameof(ModificationDetails.DateOfModification));

        context.Writer.WriteEndDocument();
    }

    public override ModificationDetails Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        context.Reader.ReadStartDocument();
        
        DateTime dateOfCreation = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(context.Reader.ReadDateTime(nameof(ModificationDetails.DateOfCreation)));

        context.Reader.ReadName(nameof(ModificationDetails.DateOfModification));

        DateTime? dateOfModification = null;

        if (context.Reader.GetCurrentBsonType() == BsonType.Null)
            context.Reader.ReadNull();
        else
            dateOfModification = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(context.Reader.ReadDateTime());

        context.Reader.ReadEndDocument();

        return new ModificationDetails(dateOfCreation, dateOfModification);
    }
}