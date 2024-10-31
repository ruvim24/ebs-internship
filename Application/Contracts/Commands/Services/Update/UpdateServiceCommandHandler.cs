using Application.DTOs.Services;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.ServiceCommands.Update;
public record UpdateServiceCommand(UpdateServiceDto Model) : IRequest<Result<ServiceDto>>;
public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Result<ServiceDto>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateServiceDto> _validator;

    public UpdateServiceCommandHandler(IServiceRepository serviceRepository, IMapper mapper, IValidator<UpdateServiceDto> validator)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<Result<ServiceDto>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if(!validationResult.IsValid) return Result.Fail($"Validation failed for{request.Model}");
        
        var service = _mapper.Map<Service>(request.Model);
        await _serviceRepository.UpdateAsync(service);
        return Result.Ok(_mapper.Map<ServiceDto>(service));
    }
}