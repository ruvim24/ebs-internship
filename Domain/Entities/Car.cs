using FluentResults;

namespace Domain.Entities
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

        private Car() { }
        private Car(int customerId,  string maker, string model, string plateNumber, string vin)
        {
            CustomerId = customerId;
            Maker = maker;
            Model = model;
            PlateNumber = plateNumber;
            VIN = vin;
        }

        public static Result<Car> Create(int customerId, string maker, string model, string plateNumber, string vin)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(maker))
                errors.Add("Maker is required.");

            if (string.IsNullOrWhiteSpace(model))
                errors.Add("Model is required.");

            if (string.IsNullOrWhiteSpace(plateNumber))
                errors.Add("PlateNumber is required.");

            if (string.IsNullOrWhiteSpace(vin))
                errors.Add("VIN is required.");

            if (errors.Any())
                return Result.Fail(string.Join(", ", errors));
            
            return Result.Ok(new Car(customerId, maker, model, plateNumber, vin)); 
        }
    }
}
