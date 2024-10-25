using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.Get;

public class GetServiceCommandHandler : IRequestHandler<GetServiceCommand, Result<Service>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public GetServiceCommandHandler(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }
    public async Task<Result<Service>> Handle(GetServiceCommand request, CancellationToken cancellationToken)
    {
        if (request.Id < 0) return Result.Fail("Invalid Service Id");
        var service = await _serviceRepository.GetByIdAsync(request.Id);
        if (service == null) return Result.Fail("Service not found");
        return Result.Ok(_mapper.Map<Service>(service));

    }
}