using Domain.Enums;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Services;
namespace Application.Contracts.Queries.Services.GetByType;

public record GetServiceByTypeQuery(ServiceType Type) : IRequest<Result<IEnumerable<ServiceDto>>>;
public class GetServiceByTypeCommandHandler : IRequestHandler<GetServiceByTypeQuery, Result<IEnumerable<ServiceDto>>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public GetServiceByTypeCommandHandler(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<ServiceDto>>> Handle(GetServiceByTypeQuery request, CancellationToken cancellationToken)
    {
        var services = await _serviceRepository.GetByTypeAsync(request.Type);
        if(services == null || !services.Any()) return Result.Fail($"No service found for type {request.Type}");
        return Result.Ok(_mapper.Map<IEnumerable<ServiceDto>>(services));
    }
}