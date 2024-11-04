using Application.DTOs.Services;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.Services.GetByMaster;

public record GetServiceByMasterQuery(int MasterId) : IRequest<Result<IEnumerable<ServiceDto>>>;

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
        if (request.MasterId <= 0) return Result.Fail("Master Id is should be greater than 0");
        var service = await _serviceRepository.GetServicesByMasterAsync(request.MasterId);
        if (service == null ) return Result.Fail("Service not found");
        return Result.Ok(_mapper.Map<IEnumerable<ServiceDto>>(service));
    }

}