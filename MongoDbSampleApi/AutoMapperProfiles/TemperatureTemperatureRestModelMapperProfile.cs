using AutoMapper;
using MongoDbSandbox.Models.Entities;
using MongoDbSandbox.Models.RestModels;

namespace MongoDbSandbox.AutoMapperProfiles;

public class TemperatureTemperatureRestModelMapperProfile : Profile
{
    public TemperatureTemperatureRestModelMapperProfile()
        => CreateMap<Temperature, TemperatureRestModel>().ReverseMap();
}