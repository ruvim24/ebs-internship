using FluentValidation;
using Shared.Dtos.Appointments;

namespace Shared.Validators.Appointments;

public class CreateAppointmentDtoValidator : AbstractValidator<CreateAppointmentDto>
{
    public CreateAppointmentDtoValidator()
    {
        RuleFor(x => x.ServiceId)
            .GreaterThan(0).WithMessage("Service Id must be greater than 0");
        
        RuleFor(x => x.CarId)
            .GreaterThan(0).WithMessage("Car Id must be greater than 0");
        
        RuleFor(x => x.SlotId)
            .GreaterThan(0).WithMessage("Slot Id must be greater than 0");
    }
}