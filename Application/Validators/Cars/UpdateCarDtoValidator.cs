using Application.DTOs.Car;
using Application.DTOs.CarDtos;
using FluentValidation;

namespace Application.Validators.CarValidatoros;

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
}