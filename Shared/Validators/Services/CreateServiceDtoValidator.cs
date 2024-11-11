using FluentValidation;
using Shared.Dtos.Services;

namespace Shared.Validators.Services;

public class CreateServiceDtoValidator : AbstractValidator<CreateServiceDto>
{
    public CreateServiceDtoValidator()
    {
        RuleFor(x => x.MasterId)
            .GreaterThan(0).WithMessage("MasterId must be greater than 0");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(30).WithMessage("Name must be between 3 and 30 characters");
        
        RuleFor(x => x.Description)
            .MaximumLength(100).WithMessage("Description must maximum 100 characters");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.ServiceType)
            .NotEmpty().WithMessage("Service type is required");
        
        RuleFor(x => x.Duration)
            .NotEmpty().WithMessage("Duration is required")
            .GreaterThan(0).WithMessage("Duration must be greater than 0")
            .LessThan(180).WithMessage("Duration must be less than 1000");


    }
}