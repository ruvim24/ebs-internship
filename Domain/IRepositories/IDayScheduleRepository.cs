using Domain.Entities.Schedule;

namespace Domain.IRepositories;

public interface IDayScheduleRepository
{
    Task AddAsync(DaySchedule entity);
    Task<DaySchedule> GetByIdAsync(int id);
    Task<IEnumerable<DaySchedule>> GetAllAsync();
    Task UpdateAsync(DaySchedule entity);
    Task DeleteByIdAsync(int id);
    
    // aditional
    Task<IEnumerable<DaySchedule>> GetByDayOfWeekAsync(DayOfWeek dayOfWeek);
}
