using Domain.Entities.Appointments;
using Domain.Entities.ObjectValues;

namespace Domain.Entities.Users.Customer
{
    public sealed class Customer : BaseUser
    {
        private ICollection<Appointment> _appoitmentsHistory;
        public IReadOnlyCollection<Appointment> GetAppointmentsHistory => (IReadOnlyCollection<Appointment>)_appoitmentsHistory;

        public Customer(FullName fullName, Contacts contacts) : base(fullName, contacts)
        {
            _appoitmentsHistory = new List<Appointment>();
        }

        public Customer Create(FullName fullName, Contacts contacts)
        {
            return new Customer(fullName, contacts);
        }
        public void AddAppointment(Appointment appointment)
        {
            if(appointment == null)
            {
                throw new ArgumentNullException("appointment is null");
            }
            _appoitmentsHistory.Add(appointment);
        }

    }
}
