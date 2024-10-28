using Application.Contracts.Commands.UserCommands.Create;
using Application.Contracts.Commands.UserCommands.Update;
using Application.Contracts.Queries.UserQueries.Get;
using Application.Contracts.Queries.UserQueries.GetAll;
using Application.Contracts.Queries.UserQueries.GetByRole;
using Application.DTOs.UserDtos;
using Domain.Enums;
using Domain.IRepositories;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetUserQuery(id));
            if (result.IsSuccess) return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            if(result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpGet("/role")]
        public async Task<IActionResult> GetUserByRole([FromBody] Role role)
        {
            var users = await _mediator.Send(new GetUsersByRoleCommand(role));
            if(users.IsFailed) return BadRequest(users.Errors);
            return Ok(users.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto createUserDto)
        {
            var result = await _mediator.Send(new CreateUserCommand(createUserDto));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserDto updateUserDto)
        {
            var result = await _mediator.Send(new UpdateUserCommand(updateUserDto));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok();
        }
    }
}
