using System.Windows.Input;
using Domain.Entities;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Dtos.Users;

namespace Application.Contracts.Commands.Users.LogIn;

public record LoginCommand(LoginDto Model) : IRequest<Result>;
public class LoginCommandHandler : IRequestHandler<LoginCommand, Result>
{
    private SignInManager<User> _signInManager;
    private IValidator<LoginDto> _loginValidator;
    private IMediator _mediator;

    public LoginCommandHandler(SignInManager<User> signInManager, IValidator<LoginDto> loginValidator, IMediator mediator)
    {
        _signInManager = signInManager;
        _loginValidator = loginValidator;
        _mediator = mediator;
    }
    public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result =  _loginValidator.Validate(request.Model);
        if (!result.IsValid)
        {
            var errors = string.Join(',', result.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
        
        var user = await _signInManager.PasswordSignInAsync(request.Model.Username, request.Model.Password, false, false);
        if (!user.Succeeded)
        {
            return Result.Fail(result.Errors.ToString());
        }
        return Result.Ok();
    }
}