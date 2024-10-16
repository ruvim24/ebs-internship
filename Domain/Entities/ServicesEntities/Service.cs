namespace Domain.Entities.ServicesEntities
{
    public sealed class Service
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public decimal Price { get; private set; }
        public TimeSpan Duration { get; private set; }
        // ?? mastersAllowed

        private Service(ServiceParam serviceParam)
        {
            Id = Guid.NewGuid();  
            Name = serviceParam.serviceName;
            Description = serviceParam.description;
            ServiceType = serviceParam.serviceType;
            Price = serviceParam.price;
            Duration = serviceParam.duration;
        }

        public static Service Create(ServiceParam serviceParam)
        { 
            return new Service(serviceParam);
        }


    }
}
