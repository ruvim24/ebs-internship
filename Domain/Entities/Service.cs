using Domain.Entities.Enums;

namespace Domain.Domain.Entitites
{
    public class Service
    {
        public int Id { get; private set; }
        public int MasterId { get; private set; } 
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public decimal Price { get; private set; }
        public TimeSpan Duration { get; private set; }


        private Service(int masterId, string name, string description, ServiceType serviceType, decimal price, TimeSpan duration)
        {
            MasterId = masterId;
            Name = name;
            Description = description;
            ServiceType = serviceType;
            Price = price;
            Duration = duration;
        }

        public static Service Create(int masterId, string name, string description, ServiceType serviceType, decimal price, TimeSpan duration)
        {
            return new Service(masterId, name, description, serviceType, price, duration);
        }
    }
}
