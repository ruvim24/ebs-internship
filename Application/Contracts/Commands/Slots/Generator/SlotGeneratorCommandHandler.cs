using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.Slots.Generator;


public record SlotGeneratorCommand() : IRequest<Result>;
public class SlotGeneratorCommandHandler : IRequestHandler<SlotGeneratorCommand, Result>
{
    private readonly ISlotRepository _slotRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IDayScheduleRepository _dayScheduleRepository;
    private readonly IUserRepository _userRepository;

    public SlotGeneratorCommandHandler(ISlotRepository slotRepository, IServiceRepository serviceRepository, IDayScheduleRepository dayScheduleRepository, IUserRepository userRepository)
    {
        _slotRepository = slotRepository;
        _serviceRepository = serviceRepository;
        _dayScheduleRepository = dayScheduleRepository;
        _userRepository = userRepository;
    }
    public async Task<Result> Handle(SlotGeneratorCommand request, CancellationToken cancellationToken)
    {
        var services = await _serviceRepository.GetAllAsync();
        if (services == null || !services.Any()) return Result.Fail("No service available");

        const  int nDays = 7;
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var endDate  = startDate.AddDays(nDays);
        
        for (var date = startDate; date < endDate; date = date.AddDays(1))
        {
            foreach (var service in services)
            {
                var existSlotsForDate =  await _slotRepository.ExistsSlotsForDateAsync(service.MasterId, date);
                if(existSlotsForDate) continue;
                
                //verificare daca exista asa master in useri
                /*var masterExists = await _userRepository.GetByIdAsync(service.MasterId);
                if (masterExists == null) continue;*/
                
                var masterExists = await _userRepository.GetByIdAsync(service.MasterId);
                if (masterExists == null)
                {
                    Console.WriteLine($"Master with Id {service.MasterId} does not exist. Skipping service: {service.Name}");
                    continue;
                }

                
                await GenerateSlotsForServiceAndDate(service.MasterId, service.Duration, date );
            }
            
        }
        return Result.Ok();
    }
    
    public async Task GenerateSlotsForServiceAndDate(int masterId, int duration, DateOnly date)
    {
        var dayOfWeek = date.DayOfWeek;
        var daySchedule = await _dayScheduleRepository.GetByDayOfWeekAsync(dayOfWeek);
        if (daySchedule == null) return;

        // Convertim startDateTime și endDateTime la UTC
        var startDateTime = DateTime.SpecifyKind(date.ToDateTime(daySchedule.StartTime), DateTimeKind.Utc);
        var endDateTime = DateTime.SpecifyKind(startDateTime.AddMinutes(duration), DateTimeKind.Utc);

        // Asigură-te că daySchedule.EndTime este și ea convertită la UTC
        var endTime = DateTime.SpecifyKind(date.ToDateTime(daySchedule.EndTime), DateTimeKind.Utc);

        while (startDateTime <= endTime)
        {
            // Verifică dacă startDateTime este în trecut
            if (startDateTime < DateTime.UtcNow)
            {
                startDateTime = endDateTime;
                endDateTime = startDateTime.AddMinutes(duration);
                continue;
            }

            var slotResult = Slot.Create(masterId, startDateTime, endDateTime);
            if (slotResult.IsFailed)
            {
                startDateTime = endDateTime;
                endDateTime = startDateTime.AddMinutes(duration);
                continue; // sau gestionează cum consideri necesar
            }

            var slot = slotResult.Value;
            await _slotRepository.AddAsync(slot);

            // Actualizează startDateTime și endDateTime pentru următorul slot
            startDateTime = endDateTime;
            endDateTime = startDateTime.AddMinutes(duration);
        }
    }

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*public async Task GenerateSlotsForServiceAndDate(int masterId, int duration,  DateOnly date)
    {
        var dayOfWeek = date.DayOfWeek;
        var daySchedule = await _dayScheduleRepository.GetByDayOfWeekAsync(dayOfWeek);
        if (daySchedule == null) return;

        var startDateTime = date.ToDateTime(daySchedule.StartTime);
        var endDateTime = date.ToDateTime(daySchedule.StartTime.AddMinutes(duration));

        while (TimeOnly.FromDateTime(startDateTime) <= daySchedule.EndTime)
        {
            if (startDateTime < DateTime.Now) return;
            

            var slot = Slot.Create(masterId, startDateTime, endDateTime).Value;
            
            await _slotRepository.AddAsync(slot);
            startDateTime = endDateTime;
            endDateTime = startDateTime.AddMinutes(duration);
        }
    }*/
}