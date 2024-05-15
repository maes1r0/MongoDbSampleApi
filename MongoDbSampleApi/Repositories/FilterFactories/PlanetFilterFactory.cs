using AutoMapper;
using MongoDB.Driver;
using MongoDbSampleApi.Extensions;
using MongoDbSampleApi.Models.Entities;
using MongoDbSampleApi.Models.FilterModels;
using MongoDbSampleApi.Models.RestModels;

namespace MongoDbSampleApi.Repositories.FilterFactories;

public class PlanetFilterFactory : IFilterFactory<PlanetFilterModel, PlanetRestModel, Planet>
{
    private readonly IMapper mapper;
    
    public PlanetFilterFactory(IMapper mapper)
    {
        this.mapper = mapper;
    }
    
    public UpdateDefinition<Planet> CreatePatchFilter(PlanetRestModel planet)
    {
        var updateDefinitionBuilder = Builders<Planet>.Update.Combine();

        if (planet.Name != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(planetEntity => planetEntity.Name, planet.Name);
        }

        if (planet.OrderFromSun != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(planetEntity => planetEntity.OrderFromSun, planet.OrderFromSun);
        }

        if (planet.HasRings != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(planetEntity => planetEntity.HasRings, planet.HasRings);
        }

        if (planet.MainAtmosphere != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(planetEntity => planetEntity.MainAtmosphere, planet.MainAtmosphere);
        }
        
        if (planet.SurfaceTemperatureC != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(planetEntity => planetEntity.SurfaceTemperatureC,
                mapper.Map<Temperature>(planet.SurfaceTemperatureC));
        }
        
        return updateDefinitionBuilder;
    }
    
    public FilterDefinition<Planet> CreateGetAllFilter(PlanetFilterModel planetFilterModel)
    {
        var filterDefinitionBuilder = Builders<Planet>.Filter.Empty;
        
        if(planetFilterModel.Id != null && planetFilterModel.Id.ToObjectId().Count > 0)
        {
            filterDefinitionBuilder &= Builders<Planet>.Filter.In(planetEntity => planetEntity.Id, 
                planetFilterModel.Id.ToObjectId());
        }

        if (planetFilterModel.Name != null && planetFilterModel.Name.Count > 0)
        {
            filterDefinitionBuilder &= Builders<Planet>.Filter.In(planetEntity => planetEntity.Name, planetFilterModel.Name);
        }
        
        if (planetFilterModel.OrderFromSun != null && planetFilterModel.OrderFromSun.Count > 0)
        {
            filterDefinitionBuilder &= Builders<Planet>.Filter.In(planetEntity => planetEntity.OrderFromSun, planetFilterModel.OrderFromSun);
        }
        
        if (planetFilterModel.HasRings.HasValue)
        {
            filterDefinitionBuilder &= Builders<Planet>.Filter.Eq(planetEntity => planetEntity.HasRings, planetFilterModel.HasRings);
        }

        // if (planetFilterModel.MainAtmosphere != null && planetFilterModel.MainAtmosphere.Count > 0)
        // {
        //      This implementations somehow cause InvalidCastException(MongoDB.Bson.Serialization.Serializers.StringSerializer"
        //      to MongoDB.Bson.Serialization.IBsonDocumentSerializer)
        //      filterDefinitionBuilder &= Builders<Planet>.Filter.ElemMatch(planetEntity => planetEntity.MainAtmosphere, element
        //          => planetFilterModel.MainAtmosphere.Contains(element));
        //     
        //      filterDefinitionBuilder &= Builders<Planet>.Filter.ElemMatch(planetEntity => planetEntity.MainAtmosphere, 
        //          Builders<string>.Filter.In(atmosphere => atmosphere, planetFilterModel.MainAtmosphere));
        // }
        
        return filterDefinitionBuilder;
    }
}