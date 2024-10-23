using Domain.Domain.Entitites;

namespace Domain.Services;

public interface IAdminService
{
    void CreateMaster(User master);
    void RemoveMaster(User master);
    void CreateService(Service service);
    void RemoveService(Service service);
    void UpdateDaySchedule(int dayId, TimeOnly startTime, TimeOnly endTime);
}