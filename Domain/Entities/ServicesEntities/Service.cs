using Domain.Entities.Enums;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ServicesEntities
{
    public sealed class Service
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public decimal Price { get; private set; }
        public int Duration { get; set; }
        public Status Status { get; set; }

        private readonly IList<Master> _mastersAllowed;

        private Service(int serivceId, string serviceName, string description, ServiceType serviceType, decimal price, int duration, Status status, IList<Master> mastersAllowed)
        {
            Id = serivceId;  
            Name = serviceName;
            Description = description;
            ServiceType = serviceType;
            Price = price;
            Duration = duration;
            Status = status;
            _mastersAllowed = mastersAllowed;
        }

        public static Service Create(int serivceId, string serviceName, string description, ServiceType serviceType, decimal price, int duration, Status status, IList<Master> mastersAllowed)
        {
            return new Service(serivceId, serviceName, description, serviceType, price, duration, status, mastersAllowed);
        }

        public IReadOnlyCollection<Master> GetMastersAllowed()
        {
            return _mastersAllowed.AsReadOnly();
        }
        public void AddMastersAllowed(Master master)
        {
            _mastersAllowed.Add(master);
        }

    }
}
