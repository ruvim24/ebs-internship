using Application.Contracts.Commands.DaySchedules.Update;
using Application.Contracts.Queries.DaySchedules.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.DaySchedules;

namespace API.Controllers.DaySchedule;

[ApiController]
[Route("[controller]")]
public class DayScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public DayScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllDayScheduleQuery());
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDayScheduleDto updateDto)
    {
        var result = await _mediator.Send(new UpdateDayScheduleCommand(updateDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
}