using Application.DTOs.ServiceDtos;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.GetAll;

public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, Result<IEnumerable<ServiceDto>>>
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;

    public GetAllServiceQueryHandler(IServiceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<ServiceDto>>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
    {
        var allServices = await _repository.GetAllAsync();
        if(allServices == null || !allServices.Any()) return Result.Fail("No services found");
        return Result.Ok(_mapper.Map<IEnumerable<ServiceDto>>(allServices));
    }
}