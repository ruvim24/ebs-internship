using Domain.Entities.Appointments;
using Domain.Entities.ObjectValues;
using System.Runtime.Serialization;

namespace Domain.Entities.Users.Master
{
    public sealed class Master : BaseUser
    {
        public MasterType MasterType { get; private set; }
        public ICollection<TimeSlot> Schedule { get; private set; }
        public ICollection<TimeSlot> ReservedTime { get; private set; }

        private ICollection<Appointment> _appointmentsHistory;


        private Master(FullName fullName, Contacts contacts, MasterType masterType) : base(fullName, contacts)
        {
            MasterType = masterType;
            _appointmentsHistory = new List<Appointment>();
        }

        public Master Create(FullName fullName, Contacts contacts, MasterType masterType)


            
        {
            //latter validation
            return new Master(fullName, contacts, masterType);
        }

        public void AddAppointment(Appointment appointment)
        {
            // ? validation
            if (appointment == null)
            {
                throw new ArgumentNullException("appointment is null");
            }
            _appointmentsHistory.Add(appointment);
        }

        public void AddAvailability(TimeSlot timeSlot)
        {
            Schedule.Add(timeSlot);
        }

        public bool ReserveAppointment(TimeSlot timeSlot)
        {
            foreach (var slot in Schedule)
            {
                
                if (timeSlot.StartTime >= slot.StartTime && timeSlot.EndTime <= slot.EndTime)//verificare daca este respectata limita tipului
                {
                    if (timeSlot.StartTime == slot.StartTime && slot.IsAvailable(timeSlot.Duration))
                    {
                        var reservedSlot = new TimeSlot(timeSlot.StartTime, timeSlot.EndTime);
                        var remaningSlot = new TimeSlot(timeSlot.EndTime, slot.EndTime);
                        Schedule.Remove(slot); //removing initial slot
                        Schedule.Add(remaningSlot); //adding remaning slot
                        ReservedTime.Add(reservedSlot);
                        return true;


                    }
                    else if (timeSlot.EndTime == slot.EndTime && slot.IsAvailable(timeSlot.Duration)) 
                    {
                        var reservedSlot = new TimeSlot(timeSlot.StartTime, timeSlot.EndTime);
                        var remainingSlot = new TimeSlot(slot.StartTime, timeSlot.StartTime);
                        Schedule.Remove(slot);
                        Schedule.Add(remainingSlot);
                        ReservedTime.Add(reservedSlot);

                        return true;
                    }
                    else
                    {
                        var preReserved = new TimeSlot(slot.StartTime, timeSlot.StartTime);
                        var reservedSlot = timeSlot; 
                        var afterReserved = new TimeSlot(timeSlot.EndTime, slot.EndTime);

                        Schedule.Remove(slot);
                        Schedule.Add(preReserved);
                        Schedule.Add(afterReserved);
                        ReservedTime.Add(afterReserved);

                        return true;

                        //cream 3 new sloturi
                        // 2 - ramase neocupate si 1 rezervat
                    }
                }

            }
            return false;
        }
    }
}