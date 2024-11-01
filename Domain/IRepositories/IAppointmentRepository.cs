using Domain.Entities;
using Domain.Enums;

namespace Domain.IRepositories;

public interface IAppointmentRepository
{
    Task AddAsync(Appointment entity);
    Task<Appointment?> GetByIdAsync(int id);
    Task<IEnumerable<Appointment>?> GetAllAsync();
    Task UpdateAsync(Appointment entity);
    Task DeleteAsync(Appointment entity);
    
    // aditional
    Task<IEnumerable<Appointment>?> GetByCarIdAsync(int carId);
    Task<IEnumerable<Appointment>> GetByStatusAsync(AppointmentStatus status);
    
    Task<List<Appointment>> FindAppointmentsToMarkAsExpiredAsync();
}
