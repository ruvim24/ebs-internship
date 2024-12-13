using FluentValidation;
using Shared.Dtos.DaySchedules;

namespace Shared.Validators.DaySchedules;

public class UpdateDayScheduleDtoValidator : AbstractValidator<UpdateDayScheduleDto>
{
    public UpdateDayScheduleDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id-ul must be greater than 0.");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("StartTime is required.")
            .Matches(@"^(?:[01]\d|2[0-3]):[0-5]\d$").WithMessage("StartTime must have this format: HH:mm.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("EndTime is required.")
            .Matches(@"^(?:[01]\d|2[0-3]):[0-5]\d$").WithMessage("StartTime must have this format HH:mm.")
            .Must((dto, endTime) => IsEndTimeAfterStartTime(dto.StartTime, endTime))
            .WithMessage("EndTime must be greater that StartTime.");
    }

    private bool IsEndTimeAfterStartTime(string startTime, string endTime)
    {
        if (TimeOnly.TryParse(startTime, out var start) && TimeOnly.TryParse(endTime, out var end))
        {
            return end > start;
        }
        return false;
    }
}