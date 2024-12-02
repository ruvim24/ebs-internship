using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Services;

namespace Application.Contracts.Queries.Services.GetMastersService;

public record GetMasterServiceQuery(int MasterId) : IRequest<Result<ServiceDto>>;
public class GetMasterServiceQueryHandler : IRequestHandler<GetMasterServiceQuery, Result<ServiceDto>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public GetMasterServiceQueryHandler(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }
    public async Task<Result<ServiceDto>> Handle(GetMasterServiceQuery request, CancellationToken cancellationToken)
    {
        var result = await _serviceRepository.GetServicesByMasterAsync(request.MasterId);
        if (result == null)
        {
            return Result.Fail("Service not found");
        }
        
        return Result.Ok(_mapper.Map<ServiceDto>(result));
    }
}