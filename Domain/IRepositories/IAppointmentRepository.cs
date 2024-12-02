using Domain.Entities;
using Domain.Enums;

namespace Domain.IRepositories;

public interface IAppointmentRepository
{
    Task AddAsync(Appointment entity);
    Task<Appointment?> GetByIdAsync(int id);
    Task<IEnumerable<Appointment>?> GetAllAsync();
    Task UpdateAsync(Appointment entity);
    Task<IEnumerable<Appointment>?> GetByCarIdAsync(int carId);
    public Task<IEnumerable<Appointment>?> GetbyServiceId(int serviceId);

    Task<IEnumerable<Appointment>> GetByStatusAsync(AppointmentStatus status);
    
    Task<List<Appointment>> FindAppointmentsToMarkAsExpiredAsync();

    public Task<List<Appointment>> GetCustomerAppointments(int carId);
    public Task<List<Appointment>> GetMasterAppointments(int serviceId);


}
