using Domain.Entities.Enums;
using System.Xml.Serialization;

namespace Domain.Domain.Entitites
{
    public class Appointment
    {
        public int Id { get; private set; } 
        public int CarId { get; private set; }
        public int ServiceId { get; private set; }
        public int SlotId  { get; private set; }
        public AppointmentStatus Status { get; private set; }



        private Appointment(int carId, int serviceId, int slotId)
        {
            CarId = carId;
            ServiceId = serviceId;
            SlotId = slotId;
            Status = AppointmentStatus.Scheduled;
             
        }
        public static Appointment Create(int carId, int serviceId, int slotId)
        {
            return new Appointment(carId, serviceId, slotId);
        }


        public void Complete()
        {
            if (Status == AppointmentStatus.Scheduled)
            {
                Status = AppointmentStatus.Completed;
            }
        }
        public void Cancel()
        {
            if (Status == AppointmentStatus.Scheduled)
            {
                Status = AppointmentStatus.Canceled;
            }
        }
    }
}
