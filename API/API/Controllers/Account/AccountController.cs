using Application.Contracts.Commands.Users;
using Application.Contracts.Commands.Users.LogIn;
using Application.Contracts.Commands.Users.Logout;
using Application.Contracts.Commands.Users.Register;
using Application.Contracts.Queries.Users.GetLoggedUser;
using Application.Contracts.Queries.Users.IsAuth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Users;

namespace API.Controllers.Account;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IMediator _mediator, IHttpContextAccessor httpContextAccessor) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _mediator.Send(new RegisterCommand(registerDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        
        return Ok("Registered successfully");
    }
    
    [HttpPost("register-master")]
    public async Task<IActionResult> RegisterMaster(RegisterDto registerDto)
    {
        var result = await _mediator.Send(new RegisterMasterCommand(registerDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        
        return Ok("Registered successfully");
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _mediator.Send(new LoginCommand(loginDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        
        return Ok("Logged in successfully");
    }
    
    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var result = await _mediator.Send(new LogoutCommand());
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok("Logged out successfully.");
    }
    
    [Authorize( Roles = "Admin" )]
    [HttpPost("asign-role")]
    public async Task<IActionResult> AsignRole([FromBody] AsignRoleDto asignRoleDto)
    {
        var result = await _mediator.Send(new AsignRoleUserCommand(asignRoleDto));
        if(result.IsFailed) 
            return BadRequest(result.Errors);
        return Ok("Asigned role successfully.");
    }

    [Authorize]
    [HttpGet("user-info")]
    public async Task<IActionResult> Me()
    {
        var result = await _mediator.Send(new GetLoggedUserInfoCommand());
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
    
    [Authorize]
    [HttpGet("isAuthenticated")]
    public async Task<IActionResult> IsAuthenticated()
    {
        var result = await _mediator.Send(new IsAuthQuery());

        if (result.IsFailed) return Unauthorized();
        
        return Ok(result.Value);
    }
}