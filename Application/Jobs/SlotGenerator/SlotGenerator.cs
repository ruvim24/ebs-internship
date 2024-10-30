using Application.DTOs.ServiceDtos;
using Domain.Entities;
using Domain.Enums;
using Domain.IRepositories;
using FluentResults;
using Quartz;

namespace Application.Jobs.SlotGenerator;

public class SlotGenerator : IJob
{
    private readonly ISlotRepository _slotRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IDayScheduleRepository _dayScheduleRepository;

    public SlotGenerator(IUserRepository userRepository, ISlotRepository slotRepository, IServiceRepository serviceRepository, IDayScheduleRepository dayScheduleRepository)
    {
        _slotRepository = slotRepository;
        _serviceRepository = serviceRepository;
        _dayScheduleRepository = dayScheduleRepository;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var services = await _serviceRepository.GetAllAsync();
        if(services == null) return;

        var daySchedules = await _dayScheduleRepository.GetAllAsync();
        if(daySchedules == null) return;
        daySchedules = daySchedules.ToList(); //pentru a o materializa
        
        foreach (var service in services )
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
        }
    }
    
    
    












}


