using MongoDB.Bson;
using MongoDbSandbox.Models.RestModels;

namespace MongoDbSandbox.Models.FilterModels;

public class PlanetFilterModel
{
    public IReadOnlyCollection<ObjectId> Id { get; set; }
    
    public IReadOnlyCollection<string> Name { get; set; }
    
    public IReadOnlyCollection<int> OrderFromSun { get; set; }
    
    public bool HasRings { get; set; }

    public IReadOnlyCollection<string> MainAtmosphere { get; set; }
    
    public TemperatureRestModel SurfaceTemperatureC { get; set; }
}