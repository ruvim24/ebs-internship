using Application.DTOs.Users;
using FluentValidation;
using Mapster;
using Quartz.Xml.JobSchedulingData20;

namespace Application.Validators.Users;

public class RegisterUserDtoValidator : AbstractValidator<RegisterDto>
{
    public void Register(TypeAdapterConfig config)
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(6).WithMessage("Username must be at least 6 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm Password is required.")
            .Equal(x => x.Password).WithMessage("Passwords must match.");
    }
}