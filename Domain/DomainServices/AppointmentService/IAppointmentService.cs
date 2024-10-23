namespace Domain.Services;

public interface IAppointmentService
{
    void Create(int carId, int serviceId, int slotId);
}