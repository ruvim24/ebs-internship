using Application.Contracts.Commands.Users.Create;
using Application.Contracts.Commands.Users.Update;
using Application.Contracts.Queries.UserQueries.GetAll;
using Application.Contracts.Queries.Users.Get;
using Application.DTOs.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Users;

namespace API.Controllers.Users
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
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            if(result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody] UpdateUserDto updateUserDto)
        {
            var result = await _mediator.Send(new UpdateUserCommand(updateUserDto));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok();
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreateUserDto createUserDto)
        {
            var result = await _mediator.Send(new CreateUserCommand(createUserDto));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }
        
    }
}
