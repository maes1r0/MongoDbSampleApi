using AutoMapper;
using MongoDbSampleApi.Models.Entities;
using MongoDbSampleApi.Models.RestModels;

namespace MongoDbSampleApi.AutoMapperProfiles;

public class TemperatureTemperatureRestModelMapperProfile : Profile
{
    public TemperatureTemperatureRestModelMapperProfile()
        => CreateMap<Temperature, TemperatureRestModel>().ReverseMap();
}