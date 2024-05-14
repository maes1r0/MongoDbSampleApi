using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbSampleApi.DbContexts;
using MongoDbSampleApi.Models.Entities;
using MongoDbSampleApi.Models.FilterModels;
using MongoDbSampleApi.Models.RestModels;
using MongoDbSandbox.Repositories.FilterFactories;

namespace MongoDbSampleApi.Repositories;

internal class PlanetRepository : IPlanetRepository
{
    private readonly IMongoCollection<Planet> planets;
    private readonly IMapper mapper;
    private readonly IFilterFactory<PlanetFilterModel, PlanetRestModel, Planet> filterFactory;
    
    public PlanetRepository(
        IFilterFactory<PlanetFilterModel, PlanetRestModel, Planet> filterFactory,
        IMapper mapper,
        GuidesDbContext context)
    {
        this.filterFactory = filterFactory;
        this.mapper = mapper;
        planets = context.Planets;
    }
    
    public async Task AddAsync(PlanetRestModel planetRestModel)
        => await planets.InsertOneAsync(mapper.Map<Planet>(planetRestModel));
    
    public async Task<PlanetRestModel> GetAsync(ObjectId id)
        => mapper.Map<PlanetRestModel>(await planets.Find(planet => planet.Id == id).SingleOrDefaultAsync());
    
    public async Task<IReadOnlyCollection<PlanetRestModel>> GetAllAsync(PlanetFilterModel planetFilterModel)
        => (await planets.Find(filterFactory.CreateGetAllFilter(planetFilterModel)).ToListAsync())
            .ConvertAll(mapper.Map<Planet, PlanetRestModel>);
        
    public async Task<bool> UpdateAsync(PlanetRestModel planetRestModel)
    {
        var result = await planets.ReplaceOneAsync(planet => planet.Id == planetRestModel.Id,
            mapper.Map<Planet>(planetRestModel));
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }
    
    public async Task<PlanetRestModel> UpdateAndGetAsync(PlanetRestModel planetRestModel)
    {
        var result = await planets.FindOneAndReplaceAsync(planet => planet.Id == planetRestModel.Id,
            mapper.Map<Planet>(planetRestModel));
        return mapper.Map<PlanetRestModel>(result);
    }
    
    public async Task<bool> BatchUpdateAsync(IReadOnlyCollection<ObjectId> ids, PlanetRestModel updateModel)
    {
        var filter = Builders<Planet>.Filter.In(planet => planet.Id, ids);
        
        var result = await planets.UpdateManyAsync(filter, filterFactory.CreatePatchFilter(updateModel));
        return result.IsAcknowledged && result.ModifiedCount == ids.Count;
    }
    
    public async Task<bool> PatchAsync(PlanetRestModel planetRestModel)
    {
        var result = await planets.UpdateOneAsync(planet => planet.Id == planetRestModel.Id,
            filterFactory.CreatePatchFilter(planetRestModel));
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }
    
    public async Task<PlanetRestModel> PatchAndGetAsync(PlanetRestModel planetRestModel)
    {
        var result = await planets.FindOneAndUpdateAsync(planet => planet.Id == planetRestModel.Id,
            filterFactory.CreatePatchFilter(planetRestModel));
        return mapper.Map<PlanetRestModel>(result);
    }
    
    public async Task<bool> DeleteAsync(ObjectId id)
    {
        var result = await planets.DeleteOneAsync(planet => planet.Id == id);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
    
    public async Task<bool> BatchDeleteAsync(IReadOnlyCollection<ObjectId> ids)
    {
        var filter = Builders<Planet>.Filter.In(planet => planet.Id, ids);
        
        var result = await planets.DeleteManyAsync(filter);
        return result.IsAcknowledged && result.DeletedCount == ids.Count;
    }
}