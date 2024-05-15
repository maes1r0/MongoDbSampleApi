using AutoMapper;
using MongoDbSampleApi.Extensions;
using MongoDbSampleApi.Models.Entities;
using MongoDbSampleApi.Models.RestModels;

namespace MongoDbSampleApi.AutoMapperProfiles;

public class PlanetPlanetRestModelMapperProfile : Profile
{
    public PlanetPlanetRestModelMapperProfile()
        => CreateMap<Planet, PlanetRestModel>()
            .ForMember(member => member.Id,
                option => option.MapFrom(model => model.Id.ToString()))
            .ForMember(member => member.SurfaceTemperatureC,
                option => option.MapFrom(model => model.SurfaceTemperatureC))
            .ReverseMap();
}