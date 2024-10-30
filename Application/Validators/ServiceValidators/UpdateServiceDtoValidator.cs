using Application.DTOs.ServiceDtos;
using FluentValidation;

namespace Application.Validators.ServiceValidators;

public class UpdateServiceDtoValidator : AbstractValidator<UpdateServiceDto>
{
    public UpdateServiceDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("MasterId must be greater than 0");
        
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");
        
        RuleFor(x => x.Duration)
            .NotEmpty().WithMessage("Duration is required")
            .GreaterThan(0).WithMessage("Duration must be greater than 0")
            .LessThan(180).WithMessage("Duration must be less than 1000");
    }
    
}