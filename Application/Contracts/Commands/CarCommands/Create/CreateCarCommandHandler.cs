using Application.DTOs.Car;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.CarCommands.Create;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IValidator<CreateCarCommand> _validator;
    private readonly IMapper _mapper;

    public CreateCarCommandHandler(ICarRepository carRepository, IValidator<CreateCarCommand> validator, IMapper mapper>)
    {
        _carRepository = carRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<Result<CarDto>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
        
        var car = _mapper.Map<Car>(request);
        var createCar = Car.Create(car.CustomerId, car.Maker, car.Model, car.PlateNumber, car.VIN);
        await _carRepository.AddAsync(createCar.Value);
        return Result.Ok(_mapper.Map<CarDto>(car));
    }
}