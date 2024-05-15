using Microsoft.EntityFrameworkCore;
using MongoDbSampleApi.AutoMapperProfiles;
using MongoDbSampleApi.DbContexts;
using MongoDbSampleApi.Models.Entities;
using MongoDbSampleApi.Models.FilterModels;
using MongoDbSampleApi.Models.RestModels;
using MongoDbSampleApi.Repositories;
using MongoDbSampleApi.Repositories.FilterFactories;
using MongoDbSampleApi.Services;

namespace MongoDbSampleApi.Extensions;

public static class ServiceInitializer
{
    public static void AddAppSettingsConfiguration(this WebApplicationBuilder builder)
    {
        var appSettingsFileName = builder.Environment.IsDevelopment() 
            ? ApplicationConstants.DevelopmentAppSettingsFileName : ApplicationConstants.AppSettingsFileName;
        
        var appSettingsConfiguration = new ConfigurationBuilder().AddJsonFile(appSettingsFileName).Build();
        builder.Configuration.AddConfiguration(appSettingsConfiguration);
    }
    
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<GuidesDbContext>(options => options.UseMongoDB(
            configuration["ConnectionString"] ?? throw new ArgumentException("Connection string is required."),
            configuration["DatabaseName"] ?? throw new ArgumentException("Connection string is required.")));
    
    public static void AddAutoMapper(this IServiceCollection services) 
        => services.AddAutoMapper(config =>
        {
            config.AddProfile<TemperatureTemperatureRestModelMapperProfile>();
            config.AddProfile<PlanetPlanetRestModelMapperProfile>();
        });
    
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IFilterFactory<PlanetFilterModel, PlanetRestModel, Planet>, PlanetFilterFactory>();
        services.AddTransient<IPlanetRepository, PlanetRepository>();
        services.AddTransient<IPlanetService, PlanetService>();
        services.AddControllers();
    }
}