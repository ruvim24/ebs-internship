using Application.DTOs.Users;
using FluentValidation;

namespace Shared.Validators.Users;

public class CreateMasterDtoValidator : AbstractValidator<CreateMasterDto>
{
    public CreateMasterDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters");
        
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber cannot be empty")
            .Matches(@"^\+373\d{8}$").WithMessage("Phone number must be in the format +373XXXXXXXX, where X is a digit.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email cannot be empty")
            .EmailAddress().WithMessage("Email is invalid")
            .MaximumLength(50).WithMessage("Email cannot be longer than 50 characters");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(10).WithMessage("Password cannot be less than 10 characters");
        
        /*RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Role cannot be empty")
            .Must(role => role == Role.Master).WithMessage("Role must be Master");*/
    }
    
}