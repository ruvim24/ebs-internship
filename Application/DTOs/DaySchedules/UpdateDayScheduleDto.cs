namespace Application.DTOs.DaySchedules;

public class UpdateDayScheduleDto
{
    public int Id { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}