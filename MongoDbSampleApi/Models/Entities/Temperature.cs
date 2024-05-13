using MongoDB.Bson;

namespace MongoDbSandbox.Models.Entities;

public class Temperature
{
    public ObjectId Id { get; set; }
    
    public double? Min { get; set; }
    
    public double? Max { get; set; }
    
    public double? Mean { get; set; }
}