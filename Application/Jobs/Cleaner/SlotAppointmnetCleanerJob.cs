
using Application.Contracts.Commands.Appointments.Expire;
using Application.Contracts.Commands.Slots.Clean;
using MediatR;
using Quartz;

namespace Application.Jobs.Cleaner;

public class SlotAppointmentCleanerJob 
{
    private readonly IMediator _mediator;

    public SlotAppointmentCleanerJob(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task Execute()
    {
        await _mediator.Send(new SlotCleanerCommand());
        await _mediator.Send(new MarkAsExpiredAppointmnetsPastDueDateCommand());
    }
}
