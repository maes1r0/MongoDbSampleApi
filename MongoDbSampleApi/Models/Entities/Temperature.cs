using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbSampleApi.Models.Entities;

public class Temperature
{
    [BsonElement("min")]
    public double? Min { get; set; }
    
    [BsonElement("max")]
    public double? Max { get; set; }
    
    [BsonElement("mean")]
    public double? Mean { get; set; }
}