using Domain.Entities.Appointments;
using Domain.Entities.ObjectValues;

namespace Domain.Entities.NewFolder
{
    public class Appointment
    {
        public Guid Id { get; set; }  

        public Guid MasterId { get; private set; }
        public User Master {  get; private set; }

        public Guid CustomerId { get; private set; }
        public User Customer { get; private set; }

        public Guid ServiceId   { get; private set; }
        public Service Service { get; private set; }
        
        public Guid CarId { get; private set; }
        public Car Car { get; private set; }
        
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public TimeSlot RezeravationTime { get; private set; }
        public AppointmentStatus Status { get; private set; } = AppointmentStatus.Scheduled;




        private Appointment(Guid masterId, Guid customerId, Guid serviceId, Guid carId, TimeSlot rezervationTime)
        {
            MasterId = masterId;
            CustomerId = customerId;
            ServiceId = serviceId;
            CarId = carId;
            RezeravationTime = rezervationTime;
        }

        public static Appointment Create(Guid masterId, Guid customerId, Guid serviceId, Guid carId, TimeSlot rezervationTime)
        {
            return new Appointment(masterId, customerId, serviceId, carId, rezervationTime);
        }

        public void Cancel(AppointmentStatus status)
        {
            if (Status == AppointmentStatus.Scheduled && status == AppointmentStatus.Canceled)
            {
                Status = status;
            }
        }
        public void Complete(AppointmentStatus status)
        {
            if (Status == AppointmentStatus.Scheduled && status == AppointmentStatus.Completed)
            {
                Status = status;
            }
                
        }
    }
}
