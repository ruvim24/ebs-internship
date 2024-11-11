using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Appointments;

namespace Application.Contracts.Commands.Appointments.Cancel;
public record CancelAppointmentCommand(int Id) : IRequest<Result<AppointmentDto>>;

public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, Result<AppointmentDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public CancelAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    public async Task<Result<AppointmentDto>> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0) { return Result.Fail("Id should be greater than 0"); }
        
        var cancelAppointment = await _appointmentRepository.GetByIdAsync(request.Id);
        
        if(cancelAppointment == null) return Result.Fail("Invalid Appointment Id");
        
        cancelAppointment.Cancel();
        await _appointmentRepository.UpdateAsync(cancelAppointment);
        
        return Result.Ok(_mapper.Map<AppointmentDto>(cancelAppointment));
    }
}