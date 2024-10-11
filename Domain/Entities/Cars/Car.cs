using Domain.Entities.ServicesEntities;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Cars
{
    public sealed class Car
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }    
        public Customer Customer { get; private set; }
        public string Maker { get; private set; }
        public string Model { get; set; }
        public string PlateNumber { get; private set; }
        public string VIN { get; private set; }
        public int Mileage { get; private set; }

        private ICollection<Service> _serviceHistory;

        public Car( Guid customerId, Customer customer, string maker, string model, string plateNumber, string vin, int mileage)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Customer = customer;
            Maker = maker;
            Model = model;
            PlateNumber = plateNumber;
            VIN = vin;
            Mileage = mileage;
            _serviceHistory = new List<Service>();
        }

        public static Car Create( Guid customerId, Customer customer, string maker, string model, string plateNumber, string vin, int mileage)
        {
            return new Car(customerId, customer, maker, model, plateNumber, vin, mileage);
        }


        public IReadOnlyCollection<Service> GetServicesHistory => (IReadOnlyCollection<Service>)_serviceHistory;
        public void AddService(Service service) => _serviceHistory.Add(service);
       

        public void ChangeMileage(int newMileage)
        {
            if (newMileage < Mileage)
            {
                throw new Exception("mileage can not be smaller than actual mielage");
            }

            Mileage = newMileage;
        }
        public void ChangePlateNumber(string newPlateNumber)
        {
            if (string.IsNullOrEmpty(newPlateNumber))
            {
                throw new Exception("PlateNumber can't be null or empty");
            }
            PlateNumber = newPlateNumber;
        }
    }
}
