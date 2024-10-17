namespace Domain.Entities.ValueObjects.Schedule
{
    public class DaySchedule
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public DaySchedule(DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
        }
    }


}
