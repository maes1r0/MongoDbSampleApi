using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDbSampleApi.Extensions;
using MongoDbSampleApi.Models.Entities;

namespace MongoDbSampleApi.DbContexts;

internal class GuidesDbContext : DbContext, IGuidesDbContext
{
    private const string PlanetCollectionName = "planet";
    
    public GuidesDbContext(IConfiguration config, DbContextOptions<GuidesDbContext> options)
        : base(options)
    {
        var client = CreateMongoClient(config);

        Planets = client.GetDatabase(config[ApplicationConstants.DatabaseFieldName]).GetCollection<Planet>(PlanetCollectionName);
    }
    
    public IMongoCollection<Planet> Planets { get; init; }

    private static MongoClient CreateMongoClient(IConfiguration config)
    {
        var settings = MongoClientSettings.FromConnectionString(config[ApplicationConstants.ConnectionFieldName]);
        return new MongoClient(settings);
    }
}