using MongoDB.Driver;
using MongoDbSandbox.Models.Entities;

namespace MongoDbSandbox.DbContexts;

public interface IGuidesDbContext
{
    IMongoCollection<Planet> Planets { get; }
}