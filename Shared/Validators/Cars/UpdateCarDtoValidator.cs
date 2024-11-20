using FluentValidation;
using Shared.Dtos.Cars;

namespace Shared.Validators.Cars;

public class UpdateCarDtoValidator : AbstractValidator<UpdateCarDto>
{
    public UpdateCarDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        
        RuleFor(x => x.PlateNumber)
            .NotNull().NotEmpty().WithMessage("PlateNumber is required.")
            .MaximumLength(7).WithMessage("PlateNumber must not exceed 7 caracters.");
    }
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UpdateCarDto>.CreateWithOptions((UpdateCarDto)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}