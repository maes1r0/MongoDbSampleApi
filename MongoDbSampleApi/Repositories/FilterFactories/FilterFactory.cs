using AutoMapper;
using MongoDB.Driver;
using MongoDbSandbox.Models.Entities;
using MongoDbSandbox.Models.FilterModels;
using MongoDbSandbox.Models.RestModels;

namespace MongoDbSandbox.Repositories.FilterFactories;

public class FilterFactory<TEntity, TEntityRestModel> : IFilterFactory<TEntity, TEntityRestModel>
{
    private readonly IMapper mapper;
    
    public FilterFactory(IMapper mapper)
    {
        this.mapper = mapper;
    }
    
    private UpdateDefinition<Planet> CreatePatchFilter(PlanetRestModel planet)
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
    
    private FilterDefinition<Planet> CreateGetAllFilter(PlanetFilterModel planetFilterModel)
    {
        var filterDefinitionBuilder = Builders<Planet>.Filter.Empty;

        if (planetFilterModel.Name != null && planetFilterModel.Name.Count != 0)
        {
            filterDefinitionBuilder &= Builders<Planet>.Filter.In(planetEntity => planetEntity.Name, planetFilterModel.Name);
        }

        if (planetFilterModel.OrderFromSun != null && planetFilterModel.OrderFromSun.Count != 0)
        {
            filterDefinitionBuilder &= Builders<Planet>.Filter.In(planetEntity => planetEntity.OrderFromSun, planetFilterModel.OrderFromSun);
        }

        if (planetFilterModel.MainAtmosphere != null && planetFilterModel.MainAtmosphere.Count != 0)
        {
            filterDefinitionBuilder &= Builders<Planet>.Filter.ElemMatch(planetEntity => planetEntity.MainAtmosphere,
                element => planetFilterModel.MainAtmosphere.Contains(element));
        }
        
        return filterDefinitionBuilder;
    }
}