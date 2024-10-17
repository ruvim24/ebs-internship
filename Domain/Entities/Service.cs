using Domain.Entities.Enums;

namespace Domain.Domain.Entitites
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
        public TimeSpan Duration { get; private set; }


        private Service(User master, string name, string description, ServiceType serviceType, decimal price, TimeSpan duration)
        {
            MasterId = master.Id;
            Master = master;
            Name = name;
            Description = description;
            ServiceType = serviceType;
            Price = price;
            Duration = duration;
        }

        public static Service Create(User master, string name, string description, ServiceType serviceType, decimal price, TimeSpan duration)
        {
            return new Service(master, name, description, serviceType, price, duration);
        }
    }
}
