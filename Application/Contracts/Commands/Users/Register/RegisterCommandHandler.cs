using Application.DTOs.Users;
using Domain.Entities;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Commands.Users.Register;

public record RegisterCommand(RegisterDto Model) : IRequest<Result>;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
{
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private IValidator<RegisterDto> _registerValidator;

    public RegisterCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IValidator<RegisterDto> registerValidator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _registerValidator = registerValidator;
    }
    
    
    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _registerValidator.ValidateAsync(request.Model);
        if(!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList(); 
            return Result.Fail(errors);
        }
        
        var user = Domain.Entities.User.Create(request.Model.FullName, request.Model.Email, request.Model.PhoneNumber, request.Model.Username);
        if (user.IsFailed)
        {
            var errors = string.Join(", ", user.Errors);
            return Result.Fail(errors);
        }
        
        var createUser = await _userManager.CreateAsync(user.Value, request.Model.Password);
        if (!createUser.Succeeded)
        {
            var errors = string.Join(", ", createUser.Errors.Select(e => e.Description));
            return Result.Fail(errors);
        }
        
        return Result.Ok();

    }
}