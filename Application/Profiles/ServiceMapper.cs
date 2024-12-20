using Domain.Entities;
using Mapster;
using Shared.Dtos.Services;

namespace Application.Profiles;

public class ServiceMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
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
            .Map(dest => dest.Price, src => src.Price)
            .ConstructUsing(src =>
                Service.Create(src.MasterId, src.Name, src.Description,src.ServiceType, src.Price, src.Duration).Value);
    }
}