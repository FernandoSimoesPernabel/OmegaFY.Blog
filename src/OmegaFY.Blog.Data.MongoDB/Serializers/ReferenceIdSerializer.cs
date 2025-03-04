﻿using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Serializers;

internal class ReferenceIdSerializer : StructSerializerBase<ReferenceId>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ReferenceId value)
        => context.Writer.WriteGuid(value.Value);

    public override ReferenceId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        => new ReferenceId(context.Reader.ReadGuid());
}