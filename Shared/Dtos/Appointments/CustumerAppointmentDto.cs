using Domain.Enums;

namespace Shared.Dtos.Appointments;

public class CustumerAppointmentDto
{
    public int Id { get; set; }
    public int SlotId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public AppointmentStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}