using Application.DTOs.Service;
using Domain.Entities;
using Mapster;

namespace Application.Profiles;

public class ServiceMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<Service, ServiceDto>.NewConfig();

        TypeAdapterConfig<ServiceDto, Service>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price);
        
        TypeAdapterConfig<CreateServiceDto, Service>.NewConfig()
            .Map(dest => dest.MasterId, src => src.MasterId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price);
    }
}