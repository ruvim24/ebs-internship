using Application.Contracts.Commands.ServiceCommands.Create;
using Application.Contracts.Commands.Services.Delete;
using Application.Contracts.Commands.Services.Update;
using Application.Contracts.Queries.ServiceQueries.Get;
using Application.Contracts.Queries.ServiceQueries.GetAll;
using Application.Contracts.Queries.ServiceQueries.GetByType;
using Application.Contracts.Queries.Services.GetByMaster;
using Application.DTOs.Services;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Controllers.Service;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CreateServiceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetServiceQuery(id));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [HttpGet("by-masterId/{masterId:int}")]
    public async Task<IActionResult> GetMasters([FromQuery] int masterId)
    {
        var result = await _mediator.Send(new GetServiceByMasterQuery(masterId));
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllServiceQuery());
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet("by-type")]
    public async Task<IActionResult> GetByType([FromQuery] ServiceType serviceType)
    {
        var result = await _mediator.Send(new GetServiceByTypeQuery(serviceType));
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateServiceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateServiceDto createService)
    {
        var result = await _mediator.Send(new CreateServiceCommand(createService));
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateServiceDto updateServiceDto)
    {
        var result = await _mediator.Send(new UpdateServiceCommand(updateServiceDto));
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteServiceCommand(id));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok();
    }
    
    
}