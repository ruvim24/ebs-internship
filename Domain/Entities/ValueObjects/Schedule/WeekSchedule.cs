namespace Domain.Entities.ValueObjects.Schedule
{
    public class WeekSchedule
    {
        private static WeekSchedule _instance;
        public static WeekSchedule Instance => _instance ?? (_instance = new WeekSchedule());


        public List<DaySchedule> DaySchedules { get; private set; }

        private WeekSchedule() { }

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