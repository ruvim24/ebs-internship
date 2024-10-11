using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.ServicesEntities;
using Domain.Entities.Users;
using Domain.Entities.Cars;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.ObjectValues;
using Domain.Entities.Enums;
using System.Runtime.InteropServices;

namespace Domain.Entities.Appointments
{
    public sealed class Appointment
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartTime { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled; // la crearea apointmentului sa fie din start pe scheduled

        public Service Service { get; set; }

        public int MasterId { get; set; }
        public Master Master { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }


        private Appointment(int id, DateTime createdAt, DateTime startTime, Service service, int masterId, Master master, int customerId, Customer customer, int carId, Car car)
        {
            Id = id;
            CreatedAt = createdAt;
            StartTime = startTime;
            Service = service;
            MasterId = masterId;
            Master = master;
            CustomerId = customerId;
            CarId = carId;
            Car = car;
        }
        public void ChangeStatus(AppointmentStatus status)
        {
            Status = status;
        }
    }
}
