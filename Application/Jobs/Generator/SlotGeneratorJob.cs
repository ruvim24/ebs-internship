
using Domain.DomainServices.SlotGeneratorService;
using Quartz;

namespace Application.Jobs.Generator;

public class SlotGeneratorJob : IJob
{
    private readonly ISlotService _slotService;

    public SlotGeneratorJob(ISlotService slotService)
    {
        _slotService = slotService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        int advanceDays = 7;
        await _slotService.Generate(advanceDays); 
    }
}
