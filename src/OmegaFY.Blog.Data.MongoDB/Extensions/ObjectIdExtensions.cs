using MongoDB.Bson;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class ObjectIdExtensions
{
    public static Guid ToGuid(this ObjectId objectId) => new Guid(objectId.ToString());
}