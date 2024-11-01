using Domain.Entities;

namespace Domain.IRepositories;

public interface IDayScheduleRepository
{
    Task AddAsync(DaySchedule entity);
    Task<DaySchedule?> GetByIdAsync(int id);
    Task<IEnumerable<DaySchedule>?> GetAllAsync();
    Task UpdateAsync(DaySchedule entity);
    Task DeleteAsync(DaySchedule entity);
    
    // aditional
    Task<DaySchedule?> GetByDayOfWeekAsync(DayOfWeek dayOfWeek);
}
