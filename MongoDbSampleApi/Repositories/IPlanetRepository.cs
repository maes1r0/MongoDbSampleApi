﻿using MongoDB.Bson;
using MongoDbSampleApi.Models.FilterModels;
using MongoDbSampleApi.Models.RestModels;

namespace MongoDbSampleApi.Repositories;

public interface IPlanetRepository
{
    Task<ObjectId> AddAsync(PlanetRestModel planetRestModel);

    Task<PlanetRestModel> GetAsync(ObjectId id);

    Task<IReadOnlyCollection<PlanetRestModel>> GetAllAsync(PlanetFilterModel planetFilterModel);

    Task<bool> UpdateAsync(PlanetRestModel planetRestModel);

    Task<PlanetRestModel> UpdateAndGetAsync(PlanetRestModel planetRestModel);
    
    Task<bool> BatchUpdateAsync(IReadOnlyCollection<ObjectId> ids, PlanetRestModel updateModel);
    
    Task<bool> PatchAsync(PlanetRestModel planetRestModel);

    Task<PlanetRestModel> PatchAndGetAsync(PlanetRestModel planetRestModel);

    Task<bool> BatchDeleteAsync(IReadOnlyCollection<ObjectId> ids);
}