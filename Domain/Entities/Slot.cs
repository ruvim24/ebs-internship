using FluentResults;

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

        public static Result<Slot> Create(DateTime startTime, DateTime endTime)
        {
            var errors = new List<string>();

            if (startTime < DateTime.Now)
                errors.Add("Start time cannot be in the past.");

            if (endTime < DateTime.Now)
                errors.Add("End time cannot be in the past.");

            if (endTime <= startTime)
                errors.Add("End time must be after start time.");

            if (errors.Any())
                return Result.Fail(string.Join(", ", errors));

            return Result.Ok(new Slot(startTime, endTime));
        }

        public bool IsAvailable() { return Availability; }
        public void SetNotAvailable() { Availability = false; }
    }
}
