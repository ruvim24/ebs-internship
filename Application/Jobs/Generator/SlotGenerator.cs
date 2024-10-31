/*
using Domain.Entities;
using Domain.IRepositories;
using Quartz;

namespace Application.Jobs.Generator;

public class SlotGenerator : IJob
{
    private readonly ISlotRepository _slotRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IDayScheduleRepository _dayScheduleRepository;

    public SlotGenerator(IUserRepository userRepository, ISlotRepository slotRepository,
        IServiceRepository serviceRepository, IDayScheduleRepository dayScheduleRepository)
    {
        _slotRepository = slotRepository;
        _serviceRepository = serviceRepository;
        _dayScheduleRepository = dayScheduleRepository;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var services = await _serviceRepository.GetAllAsync();
        if (services == null) return;
        services = services.ToList();

        const  int nDays = 7;
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var endDate  = startDate.AddDays(nDays);
        
        for (var date = startDate; date < endDate; date = date.AddDays(1))
        {
            foreach (var service in services)
            {
                var existSlotsForDate = _slotRepository.ExistsSlotsForDateAsync(service.MasterId, date).Result;
                if(existSlotsForDate) continue;
                
                GenerateSlotsForServiceAndDate(service.MasterId, service.Duration, date );
            }
            
        }
   
    }

    public async void GenerateSlotsForServiceAndDate(int masterId, int duration,  DateOnly date)
    {
        var dayOfWeek = date.DayOfWeek;
        var daySchedule = await _dayScheduleRepository.GetByDayOfWeekAsync(dayOfWeek);
        if (daySchedule == null) return;

        var startDateTime = date.ToDateTime(daySchedule.StartTime);
        var endDateTime = date.ToDateTime(daySchedule.StartTime.AddMinutes(duration));

        while (TimeOnly.FromDateTime(startDateTime) <= daySchedule.EndTime)
        {
            var slot = Slot.Create(masterId, startDateTime, startDateTime).Value;
            
            await _slotRepository.AddAsync(slot);
            startDateTime = endDateTime;
            endDateTime = startDateTime.AddMinutes(duration);
        }
    }
}


//generare sloturi pentru 7 zile inainte
// generare pentru fiecare serviciu
/*
 * se verifica daca pentru serviciul dat, la data asta, sunt in baza de date any slots generated
 * in dependenta de data la care se genereaza se afla DayOfWeek,
 * in dependenta de DayOfWeek, si de Schedule, se trece printrun while pentur a se genera pentru acea zi sloturile necesare
 #1#
 
 
 
 
 
 
 
 
 
 
 
 
/*
var daySchedules = await _dayScheduleRepository.GetAllAsync();
if (daySchedules == null) return;
daySchedules = daySchedules.ToList(); //pentru a o materializa
#1#

/*foreach (var service in services)
{
    foreach (var day in daySchedules)
    {
        var startTime = day.StartTime;
        var endTime = day.StartTime.Add(TimeSpan.FromMinutes(service.Duration));

        while (endTime < day.EndTime)
        {
            var slot = Slot.Create(service.MasterId, startTime, endTime);
        }

        startTime = endTime;
        endTime = startTime.Add(TimeSpan.FromMinutes(service.Duration));
    }
}#1#
*/
