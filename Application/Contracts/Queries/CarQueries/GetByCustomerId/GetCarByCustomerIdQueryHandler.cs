using Application.DTOs.Car;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.CarQueries.GetByCustomerId;

public class GetCarByCustomerIdQueryHandler : IRequestHandler<GetCarByCustomerIdQuery, Result<IEnumerable<CarDto>>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarByCustomerIdQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<CarDto>>> Handle(GetCarByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        if(request.Id < 0) return Result.Fail("Invalid Id");
        var car = await _carRepository.GetCarByCustomerIdAsync(request.Id);
        if (car == null) return Result.Fail("Invalid Id");
        return Result.Ok(_mapper.Map<IEnumerable<CarDto>>(car));
    }
}