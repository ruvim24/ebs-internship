namespace Domain.Domain.Entitites
{
    public class Slot
    {
        public int Id { get; private set; }
        public int MasterId { get; private set; }
        public User Master { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public bool Availability {  get; private set; }

        private Slot() { }
        private Slot(DateTime startTime, DateTime endTime)
        {
             StartTime = startTime;
            EndTime = endTime;
            Availability = true;
        }

        public static Slot Create(DateTime startTime, DateTime endTime)
        {
            return new Slot(startTime, endTime);
        }

        public bool IsAvailable() { return Availability; }
        public void SetNotAvailabile() { Availability = false; }
    }
}
