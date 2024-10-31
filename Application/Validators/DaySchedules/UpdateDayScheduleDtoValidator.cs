using Application.DTOs.DaySchedule;
using Application.DTOs.DayScheduleDtos;
using FluentValidation;

namespace Application.Validators.DaySchedulevalidators;

public class UpdateDayScheduleDtoValidator : AbstractValidator<UpdateDayScheduleDto>
{
    public UpdateDayScheduleDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        
        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("Start date cannot be empty");
        
        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("End date cannot be empty")
            .GreaterThan(x => x.StartTime).WithMessage("End time cannot be in the past");
    }    
}