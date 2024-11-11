using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Cars;

namespace Application.Contracts.Commands.Cars.Update;
public record UpdateCarCommand(UpdateCarDto Model) : IRequest<Result<CarDto>>;
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
        
        var car  = await _carRepository.GetByIdAsync(request.Model.Id);
        if(car == null) return Result.Fail($"Car with Id: {request.Model.Id} not found");
        
        _mapper.Map(request.Model, car);

        await _carRepository.UpdateAsync(car);

        return Result.Ok(_mapper.Map<CarDto>(car));
    }
}