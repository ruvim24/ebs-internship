namespace Domain.Entities.ValueObjects.Schedule
{
    public class DaySchedule
    {
        DayOfWeek DayOfWeek { get; set; }
        TimeOnly StartTime { get; set; }
        TimeOnly EndTime { get; set; }
    }


}
