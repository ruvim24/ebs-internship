using Application.DTOs.Car;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.CarQueries.GetAll;


public record GetAllCarQuery() : IRequest<Result<IEnumerable<CarDto>>>;
public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, Result<IEnumerable<CarDto>>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetAllCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<CarDto>>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllAsync();
        if(cars == null || !cars.Any()) return Result.Fail("No cars found");
        
        return Result.Ok(_mapper.Map<IEnumerable<CarDto>>(cars));
    }
}