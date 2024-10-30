using Application.Contracts.Commands.ServiceCommands.Create;
using Application.Contracts.Commands.ServiceCommands.Update;
using Application.Contracts.Queries.ServiceQueries.Get;
using Application.Contracts.Queries.ServiceQueries.GetAll;
using Application.Contracts.Queries.ServiceQueries.GetByMaster;
using Application.Contracts.Queries.ServiceQueries.GetByType;
using Application.DTOs.ServiceDtos;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllServiceQuery());
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetMastersServices([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetServiceByMasterQuery(id));
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetServicesByType([FromQuery] ServiceType serviceType)
    {
        var result = await _mediator.Send(new GetServiceByTypeQuery(serviceType));
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] UpdateServiceDto updateServiceDto)
    {
        var result = await _mediator.Send(new UpdateServiceCommand(updateServiceDto));
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [HttpPost("[action]")]
    [ProducesResponseType(typeof(CreateServiceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateServiceDto createService)
    {
        var result = await _mediator.Send(new CreateServiceCommand(createService));
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
}