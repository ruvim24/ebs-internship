using Domain.Entities.Enums;
using Domain.Entities.ObjectValues;
using Domain.Entities.Cars;
using Domain.Entities.Appointments;

namespace Domain.Entities.Users
{
    public sealed class Master : BaseUser
    {
        public MasterType MasterType { get; private set; }


        private ICollection<Appointment> _appointmentsHistory;


        private Master(FullName fullName, Contacts contacts,  MasterType masterType) : base(fullName, contacts)
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
    }
}
