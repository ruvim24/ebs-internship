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
        public Period Period { get; set; }
        public Service Service { get; set; }

        public int MasterId { get; set; }
        public Master Master { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }


        private Appointment(int id, DateTime createdAt, Period period, Service service, int masterId, Master master, int customerId, Customer customer, int carId, Car car)
        {
            Id = id;
            CreatedAt = createdAt;
            Period = period;
            Service = service;
            MasterId = masterId;
            Master = master;
            CustomerId = customerId;
            CarId = carId;
            Car = car;
        }

        //mai multi constructori pentru fiecare scenariu
        /*
         1. avem toate obiectele deja create
         2. avem doar customer -> avem si Car(from customer)
         */
        public static Appointment Create(int id, DateTime createdAt, Period period, Service service, int masterId, Master master, int customerId, Customer customer) 
        {
            
            return new Appointment(id, createdAt, period, service, masterId, master, customerId, customer, customer.Id, customer.Car);

        }


        /*public static Appointment Create(int id,
            DateTime createdAt,
            DateTime startTime,
            DateTime endTime,
            Service service,

            )
        {

        }*/
    }
}
