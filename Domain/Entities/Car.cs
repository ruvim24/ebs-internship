using System.Runtime.CompilerServices;

namespace Domain.Domain.Entitites
{
    public class Car
    {
        public int Id { get; private set; } 
        public int CustomerId { get; private set; }
        public User Customer { get; private set; }
        public string Maker { get; private set; }
        public string Model { get; private set; }
        public string PlateNumber { get; private set; }
        public string VIN { get; private set; }


        private Car(User customer,  string maker, string model, string plateNumber, string vin)
        {
            CustomerId = customer.Id;
            Customer = customer;
            Maker = maker;
            Model = model;
            PlateNumber = plateNumber;
            VIN = vin;
        }

        public static Car Create(User customer, string maker, string model, string plateNumber, string vin)
        {
            return new Car(customer, maker, model, plateNumber, vin); 
        }
    }
}
