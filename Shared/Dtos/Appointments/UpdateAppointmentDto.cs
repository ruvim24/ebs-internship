using Domain.Enums;

namespace Shared.Dtos.Appointments;

public class UpdateAppointmentDto
{
    public int Id { get; set; } 
    public AppointmentStatus Status { get; set; }
}