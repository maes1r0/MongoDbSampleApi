using MongoDB.Bson;
using MongoDbSampleApi.Extensions;
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
    
    public async Task<string> AddAsync(PlanetRestModel planetRestModel)
        => (await ArgumentValidator.HandleAsync(() => repository.AddAsync(planetRestModel), planetRestModel))
            .ToString();

    public async Task<PlanetRestModel> GetAsync(ObjectId id)
        => await ArgumentValidator.HandleAsync(() => repository.GetAsync(id), id);

    public async Task<IReadOnlyCollection<PlanetRestModel>> GetAllAsync(PlanetFilterModel planetFilterModel)
        => await ArgumentValidator.HandleAsync(() => repository.GetAllAsync(planetFilterModel), planetFilterModel);

    public async Task<bool> UpdateAsync(PlanetRestModel planetRestModel)
        => await ArgumentValidator.HandleAsync(() => repository.UpdateAsync(planetRestModel), planetRestModel);

    public async Task<PlanetRestModel> UpdateAndGetAsync(PlanetRestModel planetRestModel)
        => await ArgumentValidator.HandleAsync(() => repository.UpdateAndGetAsync(planetRestModel), planetRestModel);

    public async Task<bool> BatchUpdateAsync(IReadOnlyCollection<ObjectId> ids, PlanetRestModel updateModel)
        => await ArgumentValidator.HandleAsync(
            () => repository.BatchUpdateAsync(ids, updateModel),
            ids, updateModel);

    public async Task<bool> PatchAsync(PlanetRestModel planetRestModel)
        => await ArgumentValidator.HandleAsync(() => repository.PatchAsync(planetRestModel), planetRestModel);

    public async Task<PlanetRestModel> PatchAndGetAsync(PlanetRestModel planetRestModel)
        => await ArgumentValidator.HandleAsync(() => repository.PatchAndGetAsync(planetRestModel), planetRestModel);

    public async Task<bool> BatchDeleteAsync(IReadOnlyCollection<ObjectId> ids)
        => await ArgumentValidator.HandleAsync(() => repository.BatchDeleteAsync(ids), ids);
}