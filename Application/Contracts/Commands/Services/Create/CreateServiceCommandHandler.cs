using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Dtos.Services;

namespace Application.Contracts.Commands.Services.Create;
public record CreateServiceCommand(CreateServiceDto Model) : IRequest<Result<ServiceDto>>;
public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Result<ServiceDto>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IValidator<CreateServiceDto> _validator;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CreateServiceCommandHandler(IServiceRepository serviceRepository, IValidator<CreateServiceDto> validator, IMapper mapper, UserManager<User> userManager)
    {
        _serviceRepository = serviceRepository;
        _validator = validator;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<Result<ServiceDto>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
        
        //Master Role verification
        var master = await _userManager.FindByIdAsync(request.Model.MasterId.ToString());
        if(master == null) 
            return Result.Fail("Master not found");
        
        var hasRole = _userManager.IsInRoleAsync(master, "Master");
        if(hasRole.Result == false) 
            return Result.Fail("User not in role Master");
        
        var service = _mapper.Map<Service>(request.Model);
        var serviceCreate = Service.Create(service.MasterId, service.Name, service.Description, service.ServiceType, service.Price, service.Duration);
        await _serviceRepository.AddAsync(serviceCreate.Value);
        return Result.Ok(_mapper.Map<ServiceDto>(serviceCreate.Value));
    }
}