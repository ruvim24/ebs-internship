using FluentValidation;
using Shared.Dtos.Cars;

namespace Shared.Validators.Cars;

public class CreateCarDtoValidator : AbstractValidator<CreateCarDto>
{
    public CreateCarDtoValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Customer Id must be greater than 0");
        
        RuleFor(x => x.Maker)
            .NotNull().NotEmpty().WithMessage("Maker is required")
            .MaximumLength(30).WithMessage("Maker should have max 30 characters long");
        RuleFor(x => x.Model)
            .NotNull().NotEmpty().WithMessage("Model is required")
            .MaximumLength(30).WithMessage("Model should have max 30 characters long");
        RuleFor(x => x.PlateNumber)
            .NotNull().NotEmpty().WithMessage("PlateNumber is required")
            .MaximumLength(7).WithMessage("PlateNumber should have max 7 characters long");
        
        RuleFor(x => x.VIN)
            .NotNull().NotEmpty().WithMessage("VIN is required")
            .MaximumLength(19).WithMessage("VIN should have max 19 characters long");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateCarDto>.CreateWithOptions((CreateCarDto)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}