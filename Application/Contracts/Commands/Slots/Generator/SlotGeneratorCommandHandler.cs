using Domain.DomainServices.SlotGeneratorService;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.Slots.Generator;


public record SlotGeneratorCommand(int Days) : IRequest<Result>;

public class SlotGeneratorCommandHandler : IRequestHandler<SlotGeneratorCommand, Result>
{
    private readonly ISlotService _slotService;

    public SlotGeneratorCommandHandler(ISlotService slotService)
    {
        _slotService = slotService;
    }


    public async Task<Result> Handle(SlotGeneratorCommand request, CancellationToken cancellationToken)
    {
        if(request.Days <= 0 || request.Days >= 30) return Result.Fail("Days must be between 0 and 30");
        var result = await _slotService.Generate(request.Days);
        if(result.IsFailed) return Result.Fail("Failed to generate slot");
        return Result.Ok();
    }
}
