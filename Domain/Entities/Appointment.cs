using Domain.Enums;
using System.Xml.Serialization;
using FluentResults;

namespace Domain.Entities
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
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Appointment() { }
        private Appointment(int carId, int serviceId, int slotId)
        {
            CarId = carId;
            ServiceId = serviceId;
            SlotId = slotId;
            Status = AppointmentStatus.Scheduled;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
             
        }
        public static Result<Appointment> Create(int carId, int serviceId, int slotId)
        {
            return Result.Ok(new Appointment(carId, serviceId, slotId));
        }


        public void Complete()
        {
            if (Status == AppointmentStatus.Scheduled)
            {
                Status = AppointmentStatus.Completed;
                UpdatedAt = DateTime.Now;
                //rasing a domain event??
            }
        }
        public void Cancel()
        {
            if (Status == AppointmentStatus.Scheduled)
            {
                Status = AppointmentStatus.Canceled;
                UpdatedAt = DateTime.Now;
                //rasing a domain event??
            }
        }

        public void SetExpired()
        {
            if (Status == AppointmentStatus.Scheduled && Slot.EndTime < DateTime.Now)
            {
                Status = AppointmentStatus.Expired;
            }
        }
    }
}
