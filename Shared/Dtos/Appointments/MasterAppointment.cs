using Domain.Enums;

namespace Shared.Dtos.Appointments;

public class MasterAppointment
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? CarMaker { get; set; }
    public string? CarModel { get; set; }
    public AppointmentStatus Status { get; set; }
    
}