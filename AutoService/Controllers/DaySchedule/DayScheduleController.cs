using Application.Contracts.Commands.DaySchedules.Update;
using Application.Contracts.Queries.DayScheduleQueries.GetAll;
using Application.Contracts.Queries.DayScheduleQueries.GetByDayOfWeek;
using Application.Contracts.Queries.DaySchedules.Get;
using Application.DTOs.DaySchedules;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Controllers.DaySchedule;

[ApiController]
[Route("[controller]")]
public class DayScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public DayScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var result = await _mediator.Send(new GetDayScheduleQuery(id));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllDayScheduleQuery());
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet("day-of-week")]
    public async Task<IActionResult> GetByDay([FromQuery] DayOfWeek dayOfWeek)
    {
        var result = await _mediator.Send(new GetByDayOfWeekQuery(dayOfWeek));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDayScheduleDto updateDto)
    {
        var result = await _mediator.Send(new UpdateDayScheduleCommand(updateDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
}