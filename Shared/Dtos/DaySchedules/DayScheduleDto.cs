namespace Shared.Dtos.DaySchedules;

public class DayScheduleDto
{
    public int Id { get; private set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}