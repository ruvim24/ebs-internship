
using Application.Contracts.Commands.Appointments.Expire;
using Application.Contracts.Commands.Slots.Cleaner;
using MediatR;
using Quartz;

namespace Application.Jobs.Cleaner;

public class SlotAppointmentCleanerJob : IJob
{
    private readonly IMediator _mediator;

    public SlotAppointmentCleanerJob(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await _mediator.Send(new SlotCleanerCommand());
        await _mediator.Send(new MarkAsExpiredAppointmnetsPastDueDateCommand());
    }
}