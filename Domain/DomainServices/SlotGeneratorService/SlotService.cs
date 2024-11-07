using Domain.Entities;
using Domain.IRepositories;
using FluentResults;

namespace Domain.DomainServices.SlotGeneratorService;

public class SlotService : ISlotService
{
    private readonly ISlotRepository _slotRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IDayScheduleRepository _dayScheduleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public SlotService(ISlotRepository slotRepository, IServiceRepository serviceRepository,
        IDayScheduleRepository dayScheduleRepository, IUserRepository userRepository,
        IAppointmentRepository appointmentRepository)
    {
        _slotRepository = slotRepository;
        _serviceRepository = serviceRepository;
        _dayScheduleRepository = dayScheduleRepository;
        _userRepository = userRepository;
        _appointmentRepository = appointmentRepository;
    }
    public async Task<Result> Clean()
    {
        var unreservedSlots = await _slotRepository.GetUnReservedSlots();
        if (unreservedSlots.Count == 0) return Result.Ok();
        await _slotRepository.DeleteRangeAsync(unreservedSlots);
        return Result.Ok();
    }

    public async Task<Result> Generate(int nDays)
    {
        var services = await _serviceRepository.GetAllAsync();
        if (services == null || !services.Any()) return Result.Fail("No service available");

        //last day for wich slots was generated, if no slots exists will return DateTime.Now
        var lastDate = await _slotRepository.GetLastSlotGenerationDate();
        //period for wich we have generated slots
        var periodGenerated = lastDate.Date - DateTime.UtcNow.Date;
        //for how many day are missing slots forward
        var daysToGenerate = nDays - periodGenerated.Days;
        
        var startDate = DateOnly.FromDateTime(lastDate.Date.AddDays(1));
        var endDate  = startDate.AddDays(daysToGenerate);
        
        
        for (var date = startDate; date < endDate; date = date.AddDays(1))
        {
            foreach (var service in services)
            {
                await GenerateSlotsForServiceAndDate(service.MasterId, service.Duration, date );
            }
        }
        return Result.Ok();
    }
    
    private async Task GenerateSlotsForServiceAndDate(int masterId, int duration, DateOnly date)
    {
        var dayOfWeek = date.DayOfWeek;
        var daySchedule = await _dayScheduleRepository.GetByDayOfWeekAsync(dayOfWeek);
        if (daySchedule == null) return;

        //variables for start and end to create sltos
        var startDateTime = DateTime.SpecifyKind(date.ToDateTime(daySchedule.StartTime), DateTimeKind.Utc);
        var endDateTime = DateTime.SpecifyKind(startDateTime.AddMinutes(duration), DateTimeKind.Utc);
        //time limit to create a slot
        var endTime = DateTime.SpecifyKind(date.ToDateTime(daySchedule.EndTime), DateTimeKind.Utc);
        
        //slot creation for curent date
        while (startDateTime <= endTime)
        {
            var slotResult = Slot.Create(masterId, startDateTime, endDateTime);
            if (slotResult.IsFailed)
            {
                startDateTime = endDateTime;
                endDateTime = startDateTime.AddMinutes(duration);
                continue; 
            }

            var slot = slotResult.Value;
            await _slotRepository.AddAsync(slot);

            // update for next slot
            startDateTime = endDateTime;
            endDateTime = startDateTime.AddMinutes(duration);
        }
    }
}