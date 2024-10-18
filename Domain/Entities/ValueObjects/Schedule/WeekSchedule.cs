namespace Domain.Entities.ValueObjects.Schedule
{
    public class WeekSchedule
    {
        public int Id { get; private set; }
        public List<DaySchedule> DaySchedules { get; private set; }

        private WeekSchedule() { } 

        public WeekSchedule Create()
        {
            DaySchedules = new List<DaySchedule>();
            return this;
        }
        public void AddDaySchedule(DaySchedule daySchedule)
        {
            if (!DaySchedules.Contains(daySchedule))
            {
                DaySchedules.Add(daySchedule);
            }
            
        }
        public void UpdateDaySchedule(DaySchedule daySchedule) 
        {
            var ToUpdateDay = DaySchedules.FirstOrDefault(x => x.DayOfWeek == daySchedule.DayOfWeek);
            ToUpdateDay = daySchedule;
        }
    }
}