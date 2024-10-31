using Domain.IRepositories;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.Slots.Cleaner;

public record SlotCleanerCommand() : IRequest<Result>;
public class SlotAppointmnetCleanerCommandHandler : IRequestHandler<SlotCleanerCommand, Result>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly ISlotRepository _slotRepository;

    public SlotAppointmnetCleanerCommandHandler(IAppointmentRepository appointmentRepository, ISlotRepository slotRepository)
    {
        _appointmentRepository = appointmentRepository;
        _slotRepository = slotRepository;
    }
    public async Task<Result> Handle(SlotCleanerCommand request, CancellationToken cancellationToken)
    {
        var unreservedSlots = await _slotRepository.GetUnReservedSlots();
        if (unreservedSlots.Count == 0) return Result.Ok();
        await _slotRepository.DeleteRangeAsync(unreservedSlots);
        return Result.Ok();

    }
}