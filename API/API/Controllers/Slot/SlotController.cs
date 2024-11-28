using Application.Contracts.Commands.Slots.Clean;
using Application.Contracts.Commands.Slots.Generate;
using Application.Contracts.Queries.Slots.GetMastersAvailableSlots;
using Application.Contracts.Queries.Slots.GetSlot;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Slot;

[Route("api/[controller]")]
[ApiController]
public class SlotController : ControllerBase
{
    private readonly IMediator _mediator;

    public SlotController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{slotId:int}")]
    public async Task<IActionResult> GetSlot([FromRoute]int slotId)
    {
        var result = await _mediator.Send(new GetSlotQuery(slotId));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [HttpGet("masters-available/{masterId:int}")]
    public async Task<IActionResult> GetMasterAvailableSlots([FromRoute] int masterId)
    {
        var result = await _mediator.Send(new GetMasterAvailableSlotsQuery(masterId));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    
    [HttpPost("[action]")]
    public async Task<IActionResult> Generate([FromQuery] int advanceDays)
    {
        var result = await _mediator.Send(new SlotGeneratorCommand(advanceDays));
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Clean()
    {
        var result = await _mediator.Send(new SlotCleanerCommand());
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok();
    }
}