namespace Domain.Entities.NewFolder
{
    public class Car
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } //customerId
        public User User { get; set; } //navigation

        public string Maker { get; private set; }
        public string Model { get; set; }
        public string PlateNumber { get; private set; }
        public string VIN { get; private set; }
        public int Mileage { get; private set; }
    }
}
