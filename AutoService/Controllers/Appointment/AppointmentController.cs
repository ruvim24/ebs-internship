using Application.Contracts.Commands.Appointments.Cancel;
using Application.Contracts.Commands.Appointments.Complete;
using Application.Contracts.Commands.Appointments.Create;
using Application.Contracts.Queries.Appointments.Get;
using Application.Contracts.Queries.Appointments.GetAll;
using Application.Contracts.Queries.Appointments.GetByCarId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Appointments;

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

    //[Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {   
        var result = await _mediator.Send(new GetAppointmentQuery(id));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    //[Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllAppointmentsQuery());
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    //[Authorize(Roles = "Customer")]
    [HttpGet("carId/{carId:int}")]
    public async Task<IActionResult> GetByCar([FromRoute] int carId)
    {
        var result = await _mediator.Send(new GetAppointmentByCarIdQuery(carId));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    //[Authorize(Roles = "Customer")]
    [HttpPut("cancel/{id:int}")]
    public async Task<IActionResult> Cancel([FromRoute] int id)
    {
        var result = await _mediator.Send(new CancelAppointmentCommand(id));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    //[Authorize(Roles = "Master")]
    [HttpPut("complete/{id:int}")]
    public async Task<IActionResult> Complete([FromRoute] int id)
    {
        var result = await _mediator.Send(new CompleteAppointmentCommand(id));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
}
