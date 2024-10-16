using Domain.Entities.ServicesEntities;

namespace Domain.Entities.NewFolder
{
    public class Service
    {
        public Guid Id { get; set; }
        public Guid MasterId { get; set; }
        public User Master { get; set; }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public decimal Price { get; private set; }
        public TimeSpan Duration { get; private set; }

        private Service(Guid masterId, string name, string description, ServiceType serviceType, decimal price, TimeSpan duration) 
        {
            Id = Guid.NewGuid();
            MasterId = masterId;
            Name = name;
            Description = description;
            ServiceType = serviceType;
            Price = price;
            Duration = duration;
        }

        public static Service Create(Guid masterId, string name, string description, ServiceType serviceType, decimal price, TimeSpan duration)
        {
            return new Service(masterId, name, description, serviceType, price, duration);
        }

        public void ChangePrice(decimal price) 
        {
            if (price > 0) 
            {
                Price = price;
            }
             
        }
    }
}
