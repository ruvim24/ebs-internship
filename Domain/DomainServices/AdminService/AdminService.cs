using Domain.Domain.Entitites;
using Domain.Entities.Enums;
using Domain.IRepositories;

namespace Domain.Services;

public class AdminService : IAdminService
{
   
    private IUserRepository _userRepository;
    private IServiceRepository _serviceRepository;
    private IDayScheduleRepository _dayScheduleRepository;
    public AdminService(IUserRepository userRepository, IServiceRepository serviceRepository, IDayScheduleRepository dayScheduleRepository)
    {
        _userRepository = userRepository;
        _serviceRepository = serviceRepository;
        _dayScheduleRepository = dayScheduleRepository;
    }

    public async void CreateMaster(User master)
    {
        var masterExists = await _userRepository.GetByIdAsync(master.Id);
        if (masterExists != null && master.Role == Role.Master)
        {
            await _userRepository.AddAsync(master);
        }
        return;
    }

    public async void RemoveMaster(User master)
    {
        var masterExists = await _userRepository.GetByIdAsync(master.Id);
        //need to remove and the service of the Master??
        if (masterExists != null && masterExists.Role == Role.Master)
        {
            _userRepository.DeleteByIdAsync(master.Id);
        }
        return;
    }

    public async void CreateService(Service service)
    {
        var serviceExists = await _serviceRepository.GetByIdAsync(service.Id);
        
        if (serviceExists != null && service.Master.Role == Role.Master)
        {
            await _serviceRepository.AddAsync(service);
        }
    }

    public async void RemoveService(Service service)
    {
        var serviceExists = await _serviceRepository.GetByIdAsync(service.Id);
        if (serviceExists != null)
        {
            //delete Master from service
            _userRepository.DeleteByIdAsync(service.Master.Id);
            //delete and service
            _serviceRepository.DeleteByIdAsync(service.Id);
        }
    }

    public async void UpdateDaySchedule(int dayId, TimeOnly startTime, TimeOnly endTime)
    {
        var daySchedule = await _dayScheduleRepository.GetByIdAsync(dayId);
        if (daySchedule != null)
        {
            daySchedule.StartTime = startTime;
            daySchedule.EndTime = endTime;
            await _dayScheduleRepository.UpdateAsync(daySchedule);
        }
        return;
    }
}