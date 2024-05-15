using MongoDB.Bson;

namespace MongoDbSampleApi.Extensions;

public static class ConvertExtension
{
    public static IReadOnlyCollection<ObjectId> ToObjectId(this IReadOnlyCollection<string> objectIds)
        => objectIds.Select(ToObjectId).ToList();
    
    public static ObjectId ToObjectId(this string objectId)
        => ObjectId.TryParse(objectId, out var result)
            ? result : throw new ArgumentException("Invalid input _id");
}