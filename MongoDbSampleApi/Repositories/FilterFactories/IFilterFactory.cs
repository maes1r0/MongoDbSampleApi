using MongoDB.Driver;

namespace MongoDbSampleApi.Repositories.FilterFactories;

public interface IFilterFactory<in TGetAllFilter, in TEntityRestModel, TEntity>
{
    UpdateDefinition<TEntity> CreatePatchFilter(TEntityRestModel filter);
    
    FilterDefinition<TEntity> CreateGetAllFilter(TGetAllFilter filter);
}