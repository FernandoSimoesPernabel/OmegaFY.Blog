using MongoDB.Bson;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class ReferenceIdExtensions
{
    public static ObjectId ToObjectId(this ReferenceId referenceId) => new ObjectId(referenceId.ToString());
}