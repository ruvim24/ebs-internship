namespace Application.DTOs.Slots;

public class SlotDto
{
    public int Id { get; set; }
    public int MasterId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool Availability {  get; set; }
}