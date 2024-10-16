using Domain.Entities.ObjectValues;

namespace Domain.Entities.NewFolder
{
    public class Schedule
    {
        public Guid Id { get; private set; }
        public Guid MasterId { get; private set; } // user.RoleType == master
        public User Master { get; private set; } //Master

        public ICollection<TimeSlot> AvailableTimeslots { get; private set; }
        public ICollection<TimeSlot> ReservedTimeSlots { get; private set; }

        public Schedule(Guid userId, TimeSlot workingHours)
        {
            Guid Id = Guid.NewGuid();
            MasterId = userId;
            AvailableTimeslots.Add(workingHours);

        }



        public void AddTimeSlot(TimeSlot timeSlot)
        {
            AvailableTimeslots.Add(timeSlot);
        }

        public void RemoveTimeSlot(TimeSlot timeSlot)
        {
            if (AvailableTimeslots.Contains(timeSlot))
            {
                AvailableTimeslots.Remove(timeSlot);
            }
        }

        public void AddRezervedTimeSlot(TimeSlot rezervedTimeSlot)
        {
            ReservedTimeSlots.Add(rezervedTimeSlot);

        }

        public void RemoveRezervedTimeSlot(TimeSlot timeSlot)
        {
            if (ReservedTimeSlots.Contains(timeSlot))
            {
                ReservedTimeSlots.Remove(timeSlot);
            }
            
        }
    }
}
