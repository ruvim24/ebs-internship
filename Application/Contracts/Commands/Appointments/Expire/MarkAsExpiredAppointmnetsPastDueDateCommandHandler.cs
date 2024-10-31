using Domain.IRepositories;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.Appointments.Expire;


public record MarkAsExpiredAppointmnetsPastDueDateCommand() : IRequest<Result>;
public class MarkAsExpiredAppointmnetsPastDueDateCommandHandler : IRequestHandler<MarkAsExpiredAppointmnetsPastDueDateCommand, Result>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public MarkAsExpiredAppointmnetsPastDueDateCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    public async Task<Result> Handle(MarkAsExpiredAppointmnetsPastDueDateCommand request, CancellationToken cancellationToken)
    {
        var appointmentsToMarkExpired = await _appointmentRepository.FindAppointmentsToMarkAsExpiredAsync();
        if (appointmentsToMarkExpired.Count == 0) return Result.Ok();
        
        foreach (var appointment in appointmentsToMarkExpired)
        {
            appointment.SetExpired();
        }
        return Result.Ok();
    }
}