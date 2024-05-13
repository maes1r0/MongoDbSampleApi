using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoDbSandbox.Models.Entities;
using MongoDbSandbox.MongoDbContext;

namespace MongoDbSandbox.DbContexts;

internal class GuidesDbContext : DbContext, IGuidesDbContext
{
    private const string PlanetCollectionName = "planet";
    
    public GuidesDbContext(IConfiguration config, DbContextOptions<GuidesDbContext> options)
        : base(options)
    {
        var client = CreateMongoClient(config);

        Planets = client.GetDatabase(config["DatabaseName"]).GetCollection<Planet>(PlanetCollectionName);
    }
    
    public IMongoCollection<Planet> Planets { get; init; }

    private static MongoClient CreateMongoClient(IConfiguration config)
    {
        var settings = MongoClientSettings.FromConnectionString(config["ConnectionString"]);
        return new MongoClient(settings);
    }
}