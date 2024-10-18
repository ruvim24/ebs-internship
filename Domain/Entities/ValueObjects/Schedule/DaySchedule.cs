namespace Domain.Entities.ValueObjects.Schedule
{
    public class DaySchedule
    {
        public int Id { get; private set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }


        //just for EF
        public int WeekScheduleId { get; private set; }
        public WeekSchedule WeekSchedule { get; set; }


        public DaySchedule(DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
