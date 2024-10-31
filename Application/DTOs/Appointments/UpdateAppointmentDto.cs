using Domain.Enums;

namespace Application.DTOs.AppointmentDtos;

public class UpdateAppointmentDto
{
    public int Id { get; set; } 
    public AppointmentStatus Status { get; set; }
}