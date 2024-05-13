using AutoMapper;
using MongoDbSandbox.Models.Entities;
using MongoDbSandbox.Models.RestModels;

namespace MongoDbSandbox.AutoMapperProfiles;

public class PlanetPlanetRestModelMapperProfile : Profile
{
    public PlanetPlanetRestModelMapperProfile()
        => CreateMap<Planet, PlanetRestModel>()
            .ForMember(member => member.SurfaceTemperatureC,
                option => option.MapFrom(model => model.SurfaceTemperatureC))
            .ReverseMap();
}