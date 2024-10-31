/*using Application.Contracts.Commands.Appointments.Expire;
using Application.Contracts.Commands.Slots.Cleaner;
using Domain.Enums;
using Domain.IRepositories;
using MediatR;
using Quartz;

namespace Application.Jobs.Cleaner;

public class SlotAppointmnetCleaner : IJob
{
    private readonly IMediator _mediator;

    public SlotAppointmnetCleaner(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        await _mediator.Send(new SlotCleanerCommand());
        await _mediator.Send(new MarkAsExpiredAppointmnetsPastDueDateCommand());
    }
}



/*var unreservedSlots = await _slotRepository.GetUnReservedSlots();
await _slotRepository.DeleteRangeAsync(unreservedSlots);

var appointmentsToMarkExpired = await _appointmentRepository.FindAppointmentsToMarkAsExpiredAsync();
foreach (var appointment in appointmentsToMarkExpired)
{
    appointment.SetExpired();
}#1#*/