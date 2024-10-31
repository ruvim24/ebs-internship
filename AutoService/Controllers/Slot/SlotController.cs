using Application.Contracts.Commands.Slots.Generator;
using Application.Contracts.Queries.SlotQueries.GetById;
using Application.Contracts.Queries.SlotQueries.GetMastersAvailableSlots;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Controllers.Slot;

[Route("api/[controller]")]
[ApiController]
public class SlotController : ControllerBase
{
    private readonly IMediator _mediator;

    public SlotController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetSlotByIdQuery(id));
        if (result.IsSuccess) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet("[action]/{masterId:int}")]
    public async Task<IActionResult> GetMasterAvailableSlots([FromRoute] int masterId)
    {
        var result = await _mediator.Send(new GetMasterAvailableSlotsQuery(masterId));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Generate()
    {
        var result = await _mediator.Send(new SlotGeneratorCommand());
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok();
    }
}