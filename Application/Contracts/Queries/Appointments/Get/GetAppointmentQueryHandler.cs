using Application.DTOs.AppointmentDtos;
using Domain.DomainServices.AppointmentService;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.AppointmentQueries.Get;
public record GetAppointmentQuery(int Id) : IRequest<Result<AppointmentDto>>;
public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, Result<AppointmentDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public GetAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    public async Task<Result<AppointmentDto>> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        var result = await _appointmentRepository.GetByIdAsync(request.Id);
        if(result == null) return Result.Fail("Appointment not found");
        return Result.Ok(_mapper.Map<AppointmentDto>(result));
    }
}