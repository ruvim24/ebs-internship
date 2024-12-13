
using Domain.DomainServices.SlotGeneratorService;
using Quartz;

namespace Application.Jobs.Generator;

public class SlotGeneratorJob 
{
    private readonly ISlotService _slotService;

    public SlotGeneratorJob(ISlotService slotService)
    {
        _slotService = slotService;
    }

    public async Task Execute()
    {
        int advanceDays = 14;
        await _slotService.Generate(advanceDays); 
    }
}
