using Application.DTOs.Service;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.GetByType;

public class GetServiceByTypeCommandHandler : IRequestHandler<GetServiceByTypeCommand, Result<IEnumerable<ServiceDto>>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public GetServiceByTypeCommandHandler(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ServiceDto>>> Handle(GetServiceByTypeCommand request, CancellationToken cancellationToken)
    {
        var services = await _serviceRepository.GetByTypeAsync(request.Type);
        if(services == null || !services.Any()) return Result.Fail($"No service found for type {request.Type}");
        return Result.Ok(_mapper.Map<IEnumerable<ServiceDto>>(services));
    }
}