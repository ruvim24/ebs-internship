using Domain.Entities.Cars;
using Domain.Entities.ObjectValues;
using Domain.Entities.ServicesEntities;
using Domain.Entities.Users.Customer;
using Domain.Entities.Users.Masters;

namespace Domain.Entities.Appointments 
{
    public sealed class Appointment
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now; 

        public TimeSlot TimeSlot { get; private set; }

        public AppointmentStatus Status { get; private set; } = AppointmentStatus.Scheduled;
        public Service Service { get; private set; }

        public int MasterId { get; private set; }
        public Master Master { get; private set; }

        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        public Guid CarId { get; private set; }
        public Car Car { get; private set; }


        private Appointment(AppointmentParam appointmentParam)
        {
            Id = Guid.NewGuid();
            CreatedAt = appointmentParam.createdAt;
            TimeSlot = CalcultateTime(appointmentParam.startTime, Service.Duration);
            Service = appointmentParam.service;
            MasterId = appointmentParam.masterId;
            Master = appointmentParam.master;
            CustomerId = appointmentParam.customerId;
            CarId = appointmentParam.carId;
            Car =   appointmentParam.car;
        }

        public Appointment? Create(AppointmentParam appointmentParam)
        {
            var timeSlot = CalcultateTime(appointmentParam.startTime, appointmentParam.service.Duration);

            if (appointmentParam.master.ReserveAppointment(timeSlot))
            {
                var newAppointment =  new Appointment(appointmentParam);
                newAppointment.Master.AddAppointment(newAppointment);
                newAppointment.Customer.AddAppointment(newAppointment);

                return newAppointment;
            }

            return null;
        }
        public void ChangeStatus(AppointmentStatus status)
        {
            Status = status;
        }

        public TimeSlot CalcultateTime(DateTime startTime , TimeSpan duration)
        {
            var end = startTime + duration;
            return new TimeSlot(startTime, end);

        }
    }
}
