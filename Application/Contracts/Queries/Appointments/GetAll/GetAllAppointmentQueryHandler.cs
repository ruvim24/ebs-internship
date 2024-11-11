using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Appointments;

namespace Application.Contracts.Queries.Appointments.GetAll;


public record GetAllAppointmentsQuery() : IRequest<Result<IEnumerable<AppointmentDto>>>;
public class GetAllAppointmentQueryHandler : IRequestHandler<GetAllAppointmentsQuery, Result<IEnumerable<AppointmentDto>>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public GetAllAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<AppointmentDto>>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var result = await _appointmentRepository.GetAllAsync();
        if(result == null) return Result.Fail($"No appointments found");
        return Result.Ok(_mapper.Map<IEnumerable<AppointmentDto>>(result));
    }
}