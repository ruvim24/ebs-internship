using Domain.Entities.Appointments;
using Domain.Entities.ObjectValues;

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
            _appointmentsHistory.Add(appointment);
        }

        public void AddAvailability(TimeSlot timeSlot)
        {
            Schedule.Add(timeSlot);
        }

        /*public bool ReserveTime(Appointment appointment)
        {
            foreach (var slot in Schedule)
            {
                //verificarea daca timpul de start nu este in afara graficului si sfarsit la fel, si deasemeanea daca durata serviciului se incadreaza
                if (appointment.TimeSlot.StartTime < slot.StartTime
                    && appointment.TimeSlot.EndTime > slot.EndTime
                    && slot.IsAvailable(appointment.Service.Duration))
                {

                }
                if (appointment.StartTime >= slot.StartTime && appointment.StartTime < slot.EndTime && slot.IsAvailable(appointment.Service.Duration))
                {
                    // Gestionarea sloturilor
                    if (appointment.StartTime == slot.StartTime && appointment.StartTime + appointment.Service.Duration < slot.EndTime)
                    {
                        Schedule.Add(new TimeSlot(appointment.StartTime + appointment.Service.Duration, slot.EndTime));
                    }
                    else if (appointment.StartTime > slot.StartTime && appointment.StartTime + appointment.Service.Duration == slot.EndTime)
                    {
                        // Nu se face nimic
                    }
                    else
                    {
                        Schedule.Add(new TimeSlot(slot.StartTime, appointment.StartTime));
                        Schedule.Add(new TimeSlot(appointment.StartTime + appointment.Service.Duration, slot.EndTime));
                    }
                    Schedule.Remove(slot);
                    return true;
                }
            }
            return false;
        }*/
    }
}
