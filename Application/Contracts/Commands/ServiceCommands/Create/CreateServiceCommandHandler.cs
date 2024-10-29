using Application.DTOs.Service;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.ServiceCommands.Create;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Result<ServiceDto>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IValidator<CreateServiceDto> _validator;
    private readonly IMapper _mapper;

    public CreateServiceCommandHandler(IServiceRepository serviceRepository, IValidator<CreateServiceDto> validator, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<Result<ServiceDto>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
        
        var service = _mapper.Map<Service>(request.Model);
        var serviceCreate = Service.Create(service.MasterId, service.Name, service.Description, service.ServiceType, service.Price, service.Duration);
        await _serviceRepository.AddAsync(serviceCreate.Value);
        return Result.Ok(_mapper.Map<ServiceDto>(serviceCreate.Value));
    }
}