using Application.Contracts.Commands.CarCommands.Create;
using Application.Contracts.Commands.CarCommands.Update;
using Application.Contracts.Queries.CarQueries.Get;
using Application.Contracts.Queries.CarQueries.GetAll;
using Application.Contracts.Queries.CarQueries.GetByCustomerId;
using Application.Contracts.Queries.CarQueries.GetByVin;
using Application.DTOs.Car;
using Application.DTOs.CarDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Controllers.Car;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetCarQuery(id));   
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       var result = await _mediator.Send(new GetAllCarQuery());
       if(result.IsFailed) return BadRequest(result.Errors);
       return Ok(result.Value);
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCarByCustomerId([FromRoute] int customerId)
    {
        var result = await _mediator.Send(new GetCarByCustomerIdQuery(customerId));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpGet("vin/{vin}")]
    public async Task<IActionResult> GetCarByVin([FromRoute] string vin)
    {
        var result = await _mediator.Send(new GetCarByVinQuery(vin));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarDto createCarDto)
    {
        var result = await _mediator.Send(new CreateCarCommand(createCarDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarDto updateCarDto)
    {
        var result = await _mediator.Send(new UpdateCarCommand(updateCarDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
   
}