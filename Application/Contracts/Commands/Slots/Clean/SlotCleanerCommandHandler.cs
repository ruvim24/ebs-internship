using Domain.DomainServices.SlotGeneratorService;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.Slots.Clean;

public record SlotCleanerCommand() : IRequest<Result>;
public class SlotAppointmnetCleanerCommandHandler : IRequestHandler<SlotCleanerCommand, Result>
{
    private readonly ISlotService _slotService;

    public SlotAppointmnetCleanerCommandHandler(ISlotService slotService)
    {
        _slotService = slotService;
    }
    public async Task<Result> Handle(SlotCleanerCommand request, CancellationToken cancellationToken)
    {
        var result =  await _slotService.Clean();
        if(result.IsFailed) return Result.Fail("Failed to clean");
        return Result.Ok();

    }
}