using Domain.Entities;
using Domain.IRepositories;

namespace Persistence.DataBaseSeeder;

public class DayScheduleSeeder
{
    private readonly IDayScheduleRepository _dayScheduleRepository;

    public DayScheduleSeeder(IDayScheduleRepository dayScheduleRepository)
    {
        _dayScheduleRepository = dayScheduleRepository;
    }
    public async Task SeedAsync()
    {
        var daySchedules = await _dayScheduleRepository.GetAllAsync();

        if ( daySchedules is not null &&  daySchedules.Any()) return;
        
        var startTime = new TimeOnly(9, 0, 0);
        var endTime = new TimeOnly(18, 0, 0);
        
        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            var daySchedule = DaySchedule.Create(day, startTime, endTime);
            if(daySchedule.IsFailed) return;
            await _dayScheduleRepository.AddAsync(daySchedule.Value);
        }
    }
}