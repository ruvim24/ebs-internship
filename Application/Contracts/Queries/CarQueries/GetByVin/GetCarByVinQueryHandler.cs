using Application.DTOs.Car;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.CarQueries.GetByVin;

public class GetCarByVinQueryHandler : IRequestHandler<GetCarByVinQuery, Result<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarByVinQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }
    public async Task<Result<CarDto>> Handle(GetCarByVinQuery request, CancellationToken cancellationToken)
    {
        if(request.Vin == string.Empty || request.Vin.Count() < 17) return Result.Fail("Invalid VIN");
        var car = await _carRepository.GetCarByVINAsync(request.Vin);
        if (car == null) return Result.Fail("No car was found with this VIN");
        return Result.Ok(_mapper.Map<CarDto>(car));
    }
}