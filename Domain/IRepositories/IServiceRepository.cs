using Domain.Entities;
using Domain.Enums;

namespace Domain.IRepositories;

public interface IServiceRepository
{
    Task AddAsync(Service entity);
    Task<Service?> GetByIdAsync(int id);
    Task<ICollection<Service>?> GetAllAsync();
    Task UpdateAsync(Service entity);
    Task DeleteByIdAsync(int id);
    
    // aditional
    Task<Service?> GetServicesByMasterAsync(int masterId);
    Task<IEnumerable<Service>?> GetByTypeAsync(ServiceType type);

}
