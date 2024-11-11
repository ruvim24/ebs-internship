using FluentValidation;
using Shared.Dtos.DaySchedules;

namespace Shared.Validators.DaySchedules;

public class UpdateDayScheduleDtoValidator : AbstractValidator<UpdateDayScheduleDto>
{
    public UpdateDayScheduleDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id-ul trebuie să fie mai mare decât zero.");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("Ora de început este obligatorie.")
            .Matches(@"^(?:[01]\d|2[0-3]):[0-5]\d$").WithMessage("Ora de început trebuie să fie în format HH:mm.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("Ora de sfârșit este obligatorie.")
            .Matches(@"^(?:[01]\d|2[0-3]):[0-5]\d$").WithMessage("Ora de sfârșit trebuie să fie în format HH:mm.")
            .Must((dto, endTime) => IsEndTimeAfterStartTime(dto.StartTime, endTime))
            .WithMessage("Ora de sfârșit trebuie să fie după ora de început.");
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