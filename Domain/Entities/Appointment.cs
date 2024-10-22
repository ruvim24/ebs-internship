using Domain.Entities.Enums;
using System.Xml.Serialization;

namespace Domain.Domain.Entitites
{
    public class Appointment
    {
        public int Id { get; private set; } 
        public int CarId { get; private set; }
        public Car Car { get; private set; }
        public int ServiceId { get; private set; }
        public Service Service { get; private set; }
        public int SlotId  { get; private set; }
        public Slot Slot { get; private set; }
        public AppointmentStatus Status { get; private set; }

        private Appointment() { }
        private Appointment(Car car, Service service, Slot slot)
        {
            CarId = car.Id;
            Car = car;
            ServiceId = service.Id;
            Service = service;
            SlotId = slot.Id;
            Slot = slot;
            Status = AppointmentStatus.Scheduled;
             
        }
        public static Appointment Create(Car car, Service service, Slot slot)
        {
            return new Appointment(car, service, slot);
        }


        public void Complete()
        {
            if (Status == AppointmentStatus.Scheduled)
            {
                Status = AppointmentStatus.Completed;
                //rasing a domain event??
            }
        }
        public void Cancel()
        {
            if (Status == AppointmentStatus.Scheduled)
            {
                Status = AppointmentStatus.Canceled;
                //rasing a domain event??
            }
        }
    }
}
