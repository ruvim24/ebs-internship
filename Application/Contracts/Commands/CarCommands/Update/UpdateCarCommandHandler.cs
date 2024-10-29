using Application.DTOs.Car;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.CarCommands.Update;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Result<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IValidator<UpdateCarDto> _validator;
    private readonly IMapper _mapper;

    public UpdateCarCommandHandler(ICarRepository carRepository, IValidator<UpdateCarDto> validator, IMapper mapper)
    {
        _carRepository = carRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<Result<CarDto>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
        var car = _mapper.Map<Car>(request.Model);
        await _carRepository.UpdateAsync(car);
        return Result.Ok(_mapper.Map<CarDto>(car));
    }
}