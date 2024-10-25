using Application.DTOs.Appointment;
using Domain.Enums;
using FluentValidation;

namespace Application.Validators.AppointmentValidators;

public class UpdateAppointmentDtoValidator : AbstractValidator<UpdateAppointmentDto>
{
    public UpdateAppointmentDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        
        RuleFor(x => x.Status)
            .Must(status => status != AppointmentStatus.Scheduled).WithMessage("Cannot schedule the appointment just complete");
    }
}