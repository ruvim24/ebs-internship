namespace Domain.Domain.Entitites
{
    public class Car
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public string Maker { get; private set; }
        public string Model { get; set; }
        public string PlateNumber { get; private set; }
        public string VIN { get; private set; }
    }
}
