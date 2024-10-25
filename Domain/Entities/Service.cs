using Domain.Enums;
using FluentResults;

namespace Domain.Entities
{
    public class Service
    {
        public int Id { get; private set; }
        public int MasterId { get; private set; } 
        public User Master { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public decimal Price { get; private set; }
        public int Duration { get; private set; }


        private Service() { }
        private Service(int masterId, string name, string description, ServiceType serviceType, decimal price, int duration)
        {
            MasterId = masterId;
            Name = name;
            Description = description;
            ServiceType = serviceType;
            Price = price;
            Duration = duration;
        }

        public static Result<Service> Create(int masterId, string name, string description, ServiceType serviceType, decimal price, int duration)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
                errors.Add("Name is required.");

            if (string.IsNullOrWhiteSpace(description))
                errors.Add("Description is required.");

            if (price <= 0)
                errors.Add("Price must be greater than zero.");

            if (duration <= 0)
                errors.Add("Duration must be greater than zero.");

            if (errors.Any())
                return Result.Fail(string.Join(", ", errors));

            return Result.Ok(new Service(masterId, name, description, serviceType, price, duration));
        }
    }
}
