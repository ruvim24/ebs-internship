namespace Application.DTOs.Appointment;

public class CreateAppointmentDto
{
    public int CarId { get; set; }
    public int ServiceId { get; set; }
    public int SlotId  { get; set; }
}