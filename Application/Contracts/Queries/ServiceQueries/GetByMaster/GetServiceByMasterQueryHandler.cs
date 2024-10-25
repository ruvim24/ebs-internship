using Application.Contracts.Queries.ServiceQueries.Get;
using Application.DTOs.Service;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.GetByMaster;

public class GetServiceByMasterCommandHandler : IRequestHandler<GetServiceByMasterQuery, Result<IEnumerable<ServiceDto>>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public GetServiceByMasterCommandHandler(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ServiceDto>>> Handle(GetServiceByMasterQuery request, CancellationToken cancellationToken)
    {
        if (request.MasterId < 0) return Result.Fail("Invalid Master Id");
        var service = await _serviceRepository.GetServicesByMasterAsync(request.MasterId);
        if (service == null ) return Result.Fail("Service not found");
        return Result.Ok(_mapper.Map<IEnumerable<ServiceDto>>(service));
    }

}