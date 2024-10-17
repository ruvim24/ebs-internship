namespace Domain.Entities.ValueObjects.Schedule
{
    public class WeekSchedule
    {
        public List<DaySchedule> DaySchedules { get; private set; }

        public WeekSchedule()
        {
            DaySchedules = new List<DaySchedule>();
        }

        public void AddDaySchedule(DaySchedule daySchedule)
        {
            DaySchedules.Add(daySchedule);
        }
    }
}