using Application.DTOs.Car;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.CarQueries.Get;

public class GetCarQueryHandler : IRequestHandler<GetCarQuery, Result<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }
    public async Task<Result<CarDto>> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
        if(request.Id < 0) return Result.Fail("Invalid car Id");
        var car = await _carRepository.GetByIdAsync(request.Id);
        if (car == null) return Result.Fail("Invalid car Id");
        return Result.Ok(_mapper.Map<CarDto>(car));
    }
}

