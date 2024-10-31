using Domain.Entities;
using Domain.Enums;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContext;
namespace Persistence.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _applicationDb;

    public AppointmentRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDb = applicationDbContext;
    }
    public async Task AddAsync(Appointment entity)
    {
        _applicationDb.Appointments.Add(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task<Appointment?> GetByIdAsync(int id)   
    {
        return await _applicationDb.Appointments.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Appointment>?> GetAllAsync()
    {
        return await _applicationDb.Appointments.ToListAsync();
    }

    public async Task UpdateAsync(Appointment entity)
    {
        _applicationDb.Appointments.Update(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var appointment = await _applicationDb.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        _applicationDb.Appointments.Remove(appointment);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task<IEnumerable<Appointment>?> GetByCarIdAsync(int carId)
    {
        return await _applicationDb.Appointments.Where(a => a.CarId == carId).ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByStatusAsync(AppointmentStatus status)
    {
        return await _applicationDb.Appointments.Where(a => a.Status == status).ToListAsync();
    }

    public  async Task<List<Appointment>> FindAppointmentsToMarkAsExpiredAsync()
    {
        var expired  = await _applicationDb.Appointments
            .Where(x => x.Status == AppointmentStatus.Scheduled && x.Slot.EndTime < DateTime.Now)
            .ToListAsync();
        
        return expired;
    }
}