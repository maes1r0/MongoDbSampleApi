using MongoDB.Bson;
using MongoDbSampleApi.Models.FilterModels;
using MongoDbSampleApi.Models.RestModels;
using MongoDbSampleApi.Repositories;

namespace MongoDbSampleApi.Services;

public class PlanetService : IPlanetService
{
    private readonly IPlanetRepository repository;
    
    public PlanetService(IPlanetRepository repository)
    {
        this.repository = repository;
    }
    
    public async Task AddAsync(PlanetRestModel planetRestModel)
        => await repository.AddAsync(planetRestModel);

    public async Task<PlanetRestModel> GetAsync(ObjectId id)
        => await repository.GetAsync(id);

    public async Task<IReadOnlyCollection<PlanetRestModel>> GetAllAsync(PlanetFilterModel planetFilterModel)
        => await repository.GetAllAsync(planetFilterModel);

    public async Task<bool> UpdateAsync(PlanetRestModel planetRestModel)
        => await repository.UpdateAsync(planetRestModel);

    public async Task<PlanetRestModel> UpdateAndGetAsync(PlanetRestModel planetRestModel)
        => await repository.UpdateAndGetAsync(planetRestModel);

    public async Task<bool> BatchUpdateAsync(IReadOnlyCollection<ObjectId> ids, PlanetRestModel updateModel)
        => await repository.BatchUpdateAsync(ids, updateModel);

    public async Task<bool> PatchAsync(PlanetRestModel planetRestModel)
        => await repository.PatchAsync(planetRestModel);

    public async Task<PlanetRestModel> PatchAndGetAsync(PlanetRestModel planetRestModel)
        => await repository.PatchAndGetAsync(planetRestModel);

    public async Task<bool> BatchDeleteAsync(IReadOnlyCollection<ObjectId> ids)
        => await repository.BatchDeleteAsync(ids);
}