namespace MongoDbSampleApi.Models.RestModels;

public class PlanetRestModel
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public int? OrderFromSun { get; set; }
    
    public bool? HasRings { get; set; }

    public string[] MainAtmosphere { get; set; }
    
    public TemperatureRestModel SurfaceTemperatureC { get; set; }
}