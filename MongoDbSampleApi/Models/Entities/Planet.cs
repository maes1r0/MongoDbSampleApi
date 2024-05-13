using MongoDB.Bson;

namespace MongoDbSandbox.Models.Entities;

public class Planet
{
    public ObjectId Id { get; set; }
    
    public string Name { get; set; }
    
    public int OrderFromSun { get; set; }
    
    public bool HasRings { get; set; }

    public string[] MainAtmosphere { get; set; } = Array.Empty<string>();
    
    public Temperature SurfaceTemperatureC { get; set; }
}