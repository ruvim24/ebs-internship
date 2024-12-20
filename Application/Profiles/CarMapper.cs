using Domain.Entities;
using Mapster;
using Shared.Dtos.Cars;

namespace Application.Profiles;

public class CarMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Car, CarDto>.NewConfig();

        TypeAdapterConfig<CarDto, Car>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.Maker, src => src.Maker)
            .Map(dest => dest.Model, src => src.Model)
            .Map(dest => dest.PlateNumber, src => src.PlateNumber)
            .Map(dest => dest.VIN, src => src.VIN);
        
        TypeAdapterConfig<CreateCarDto, Car>.NewConfig()
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.PlateNumber, src => src.PlateNumber)
            .Map(dest => dest.Model, src => src.Model)
            .Map(dest => dest.VIN, src => src.VIN)
            .ConstructUsing(src => Car.Create(src.CustomerId, src.Maker, src.Model, src.PlateNumber, src.VIN).Value);


        TypeAdapterConfig<UpdateCarDto, Car>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.PlateNumber, src => src.PlateNumber);
    }
}

