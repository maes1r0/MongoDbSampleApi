using MongoDB.Bson;
using MongoDbSandbox.Models.FilterModels;
using MongoDbSandbox.Models.RestModels;

namespace MongoDbSandbox.Repositories;

public interface IPlanetRepository
{
    Task AddAsync(PlanetRestModel planetRestModel);

    Task<PlanetRestModel> GetAsync(ObjectId id);

    Task<IReadOnlyCollection<PlanetRestModel>> GetAllAsync(PlanetFilterModel planetFilterModel);

    Task<bool> UpdateAsync(PlanetRestModel planetRestModel);

    Task<PlanetRestModel> UpdateAndGetAsync(PlanetRestModel planetRestModel);
    
    Task<bool> BatchUpdateAsync(IReadOnlyCollection<ObjectId> ids, PlanetRestModel updateModel);
    
    Task<bool> PatchAsync(PlanetRestModel planetRestModel);

    Task<PlanetRestModel> PatchAndGetAsync(PlanetRestModel planetRestModel);

    Task<bool> BatchDeleteAsync(IReadOnlyCollection<ObjectId> ids);
}