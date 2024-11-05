using Application.Contracts.Commands.Cars.Create;
using Application.Contracts.Commands.Cars.Update;
using Application.Contracts.Queries.CarQueries.Get;
using Application.Contracts.Queries.Cars.GetByCustomerId;
using Application.DTOs.CarDtos;
using Application.DTOs.Cars;
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
    
    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCarByCustomerId([FromRoute] int customerId)
    {
        var result = await _mediator.Send(new GetCarByCustomerIdQuery(customerId));
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
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

}