namespace Domain.Domain.Entitites
{
    public class Slot
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Availability {  get; set; } 
    }
}
