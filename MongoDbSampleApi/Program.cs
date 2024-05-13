using Microsoft.EntityFrameworkCore;
using MongoDbSandbox.AutoMapperProfiles;
using MongoDbSandbox.DbContexts;

namespace MongoDbSandbox;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Configuration.AddConfiguration(
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
        
        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        //register db context
        builder.Services.AddDbContext<GuidesDbContext>(options => options.UseMongoDB(
            builder.Configuration["ConnectionString"] ?? throw new ArgumentException("Connection string is required."),
            builder.Configuration["DatabaseName"] ?? throw new ArgumentException("Connection string is required.")));

        //register automapper
        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile<TemperatureTemperatureRestModelMapperProfile>();
            config.AddProfile<PlanetPlanetRestModelMapperProfile>();
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}