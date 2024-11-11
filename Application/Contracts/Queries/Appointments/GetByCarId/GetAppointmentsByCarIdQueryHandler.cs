using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Appointments;

namespace Application.Contracts.Queries.Appointments.GetByCarId;


public record GetAppointmentByCarIdQuery(int CarId) : IRequest<Result<IEnumerable<AppointmentDto>>>;
public class GetAppointmentsByCarIdQueryHandler : IRequestHandler<GetAppointmentByCarIdQuery, Result<IEnumerable<AppointmentDto>>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public GetAppointmentsByCarIdQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<AppointmentDto>>> Handle(GetAppointmentByCarIdQuery request, CancellationToken cancellationToken)
    {
        if (request.CarId <= 0) return Result.Fail("Id should be greater than 0");
        var result = await _appointmentRepository.GetByCarIdAsync(request.CarId);
        if(result == null) return Result.Fail("Not Appointments Found");
        return Result.Ok(_mapper.Map<IEnumerable<AppointmentDto>>(result));
    }
}