using Domain.Entities.Enums;

namespace Domain.Domain.Entitites
{
    public class Service
    {
        public int Id { get; set; }
        public int MasterId { get; set; } 
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public decimal Price { get; private set; }
        public TimeSpan Duration { get; private set; }
    }
}
