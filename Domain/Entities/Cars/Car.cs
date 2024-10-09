﻿using Domain.Entities.ServicesEntities;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Cars
{
    public sealed class Car
    {
        public int Id { get; private set; }
        public int CustomerId { get; private set; }    
        public Customer Customer { get; private set; }
        public string Maker { get; private set; }
        public string Model { get; set; }
        public string PlateNumber { get; private set; }
        public string VIN { get; private set; }
        public int Mileage { get; private set; }

        private readonly IList<Service> _serviceHistory;

        //Customer customer,
        private Car(int id, int customerId,  string maker, string model, string plateNumber, string vin, int mileage)
        {
            Id = id;
            CustomerId = customerId;
            //Customer = customer;
            Maker = maker;
            Model = model;
            PlateNumber = plateNumber;
            VIN = vin;
            Mileage = mileage;
            _serviceHistory = new List<Service>();
        }

        //, Customer customer
        public static Car Create(int id, int customerId, string maker, string model, string plateNumber, string vin, int mileage)
        {
            return new Car(id, customerId, maker, model, plateNumber, vin, mileage);
        }


        public ICollection<Service> GetServicesHistory()
        {
            return _serviceHistory.AsReadOnly();
        }
        public void AddService(Service service)
        {
            _serviceHistory.Add(service);
        }
    }
}
