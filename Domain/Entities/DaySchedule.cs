using FluentResults;

namespace Domain.Entities
{
    public class DaySchedule
    {
        public int Id { get; private set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        private DaySchedule(DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
        }

        public static Result<DaySchedule> Create(DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime)
        {
            if (startTime >= endTime)
                return Result.Fail<DaySchedule>("Start time must be earlier than end time.");

            return Result.Ok(new DaySchedule(dayOfWeek, startTime, endTime));
        }
    }
}
