using Domain.Entities;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Commands.Users.Logout;

public record LogoutCommand() : IRequest<Result>;
public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result>
{
    private readonly SignInManager<User> _signInManager;

    public LogoutCommandHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }
    public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        
        await _signInManager.SignOutAsync();
        return Result.Ok();
    }
}