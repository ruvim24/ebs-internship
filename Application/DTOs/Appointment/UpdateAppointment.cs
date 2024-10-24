using Domain.Entities.Enums;

namespace Application.DTOs.Appointment;

public class UpdateAppointment
{
    public int Id { get; set; } 
    public AppointmentStatus Status { get; set; }
}