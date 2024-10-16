namespace Domain.Domain.Entitites
{
    public class Appointment
    {
        public int Id { get; set; } 
        public int CarId { get; set; }
        public int ServiceId { get; set; }
        public int SlotId  { get; set; }
    }
}
