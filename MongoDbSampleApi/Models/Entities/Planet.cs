using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbSampleApi.Models.Entities;

public class Planet
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("orderFromSun")]
    public int OrderFromSun { get; set; }
    
    [BsonRepresentation(BsonType.Boolean)]
    [BsonElement("hasRings")]
    public bool HasRings { get; set; }
    
    [BsonElement("mainAtmosphere")]
    public string[] MainAtmosphere { get; set; } = Array.Empty<string>();
    
    [BsonElement("surfaceTemperatureC")]
    public Temperature SurfaceTemperatureC { get; set; }
}