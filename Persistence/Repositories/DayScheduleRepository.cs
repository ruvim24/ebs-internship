using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContext;

namespace Persistence.Repositories;

public class DayScheduleRepository : IDayScheduleRepository
{
    private readonly ApplicationDbContext _applicationDb;

    public DayScheduleRepository(ApplicationDbContext applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task AddAsync(DaySchedule entity)
    {
        _applicationDb.Add(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task<DaySchedule?> GetByIdAsync(int id)
    {
        return await _applicationDb.DaySchedules.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<DaySchedule>> GetAllAsync()
    {
        return await _applicationDb.DaySchedules.ToListAsync();
    }

    public async Task UpdateAsync(DaySchedule entity)
    {
        _applicationDb.Update(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        _applicationDb.Remove(await _applicationDb.DaySchedules.FirstOrDefaultAsync(x => x.Id == id));
    }

    public async Task<IEnumerable<DaySchedule?>> GetByDayOfWeekAsync(DayOfWeek dayOfWeek)
    {
         return  _applicationDb.DaySchedules.Where(x => x.DayOfWeek == dayOfWeek);
    }
}