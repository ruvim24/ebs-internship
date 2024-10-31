using Application.Contracts.Commands.Appointments.Cancel;
using Application.Contracts.Commands.Appointments.Complete;
using Application.Contracts.Commands.Appointments.Create;
using Application.Contracts.Queries.AppointmentQueries.Get;
using Application.Contracts.Queries.AppointmentQueries.GetAll;
using Application.Contracts.Queries.AppointmentQueries.GetByCarId;
using Application.DTOs.AppointmentDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Controllers.Appointment;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentDto appointmentDto)
    {
        var result = await _mediator.Send(new CreateAppointmentCommand(appointmentDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet("{appointmentId:int}")]
    public async Task<IActionResult> Get([FromRoute] int appointmentId)
    {
        var result = await _mediator.Send(new GetAppointmentQuery(appointmentId));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllAppointmentsQuery());
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet("carId/{CarId:int}")]
    public async Task<IActionResult> GetByCar([FromRoute] int carId)
    {
        var result = await _mediator.Send(new GetAppointmentByCarIdQuery(carId));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [HttpPut("cancel/{appointmentId:int}")]
    public async Task<IActionResult> Cancel([FromRoute] int appointmentId)
    {
        var result = await _mediator.Send(new CancelAppointmentCommand(appointmentId));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [HttpPut("complete/{appointmentId:int}")]
    public async Task<IActionResult> Complete([FromRoute] int appointmentId)
    {
        var result = await _mediator.Send(new CompleteAppointmentCommand(appointmentId));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
}
