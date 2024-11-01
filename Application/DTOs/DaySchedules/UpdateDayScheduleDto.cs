namespace Application.DTOs.DaySchedules;

public class UpdateDayScheduleDto
{
    public int Id { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}