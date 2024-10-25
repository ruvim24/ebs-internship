using Domain.Enums;
using Domain.Entities;

namespace Application.DTOs.Appointment;

public class AppointmentDto
{
    public int Id { get; set; } 
    public int CarId { get; set; }
    public int ServiceId { get; set; }
    public int SlotId  { get; set; }
    public AppointmentStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}