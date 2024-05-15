namespace MongoDbSampleApi.Models.FilterModels;

public class PlanetFilterModel
{
    public IReadOnlyCollection<string> Id { get; set; }
    
    public IReadOnlyCollection<string> Name { get; set; }
    
    public IReadOnlyCollection<int> OrderFromSun { get; set; }

    public bool? HasRings { get; set; }

    //cannot be used due to InvalidCastException described in PlanetFilterFactory
    //public IReadOnlyCollection<string> MainAtmosphere { get; set; }
}