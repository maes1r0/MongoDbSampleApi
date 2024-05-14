using MongoDB.Driver;
using MongoDbSampleApi.Models.Entities;

namespace MongoDbSampleApi.DbContexts
{
    public interface IGuidesDbContext
    {
        IMongoCollection<Planet> Planets { get; }
    }
}