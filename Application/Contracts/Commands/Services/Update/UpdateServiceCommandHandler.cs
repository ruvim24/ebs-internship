using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Services;

namespace Application.Contracts.Commands.Services.Update;
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
        
        var service = await _serviceRepository.GetByIdAsync(request.Model.Id);
        if(service == null) return Result.Fail($"Service with Id: {request.Model.Id} not found");
        
        _mapper.Map(request.Model, service);
        await _serviceRepository.UpdateAsync(service);
        return Result.Ok(_mapper.Map<ServiceDto>(service));
    }
}