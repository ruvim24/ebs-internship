using Application.Contracts.Commands.Users.LogIn;
using Application.Contracts.Commands.Users.Logout;
using Application.Contracts.Commands.Users.Register;
using Application.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using FluentResults;
using FluentValidation;
using MediatR;

namespace AutoService.Controllers.Account;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private IMediator _mediator;
    

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _mediator.Send(new RegisterCommand(registerDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        
        return Ok("Registered successfully");
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _mediator.Send(new LoginCommand(loginDto));
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok("Logged in successfully");
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var result = await _mediator.Send(new LogoutCommand());
        if(result.IsFailed) return BadRequest(result.Errors);
        return Ok("Logged out successfully.");
    }
    
    //create Role
    //asign Role
}