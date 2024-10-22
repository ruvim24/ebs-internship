using Domain.Domain.Entitites;
using Domain.Entities.Enums;

namespace Domain.IRepositories;

public interface IServiceRepository
{
    Task AddAsync(Service entity);
    Task<Service> GetByIdAsync(int id);
    Task<IEnumerable<Service>> GetAllAsync();
    Task UpdateAsync(Service entity);
    Task DeleteByIdAsync(int id);
    
    // aditional
    Task<IEnumerable<Service>> GetServicesByMasterAsync(User user /* int MasterId?? */);
    Task<IEnumerable<Service>> GetByTypeAsync(ServiceType type);

}
