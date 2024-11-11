using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Appointments;

namespace Application.Contracts.Queries.Appointments.Get;
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
        if(request.Id <= 0) return Result.Fail("Id should be greater than 0");
        var result = await _appointmentRepository.GetByIdAsync(request.Id);
        if(result == null) return Result.Fail("Appointment not found");
        return Result.Ok(_mapper.Map<AppointmentDto>(result));
    }
}