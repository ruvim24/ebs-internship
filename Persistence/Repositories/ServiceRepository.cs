using Domain.Domain.Entitites;
using Domain.Entities.Enums;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContext;

namespace Persistence.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext _applicationDb;

    public ServiceRepository(ApplicationDbContext applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task AddAsync(Service entity)
    {
        _applicationDb.Services.Add(entity);
         await _applicationDb.SaveChangesAsync();
    }

    public async Task<Service> GetByIdAsync(int id)
    {
        return await _applicationDb.Services.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _applicationDb.Services.ToListAsync();
    }

    public async Task UpdateAsync(Service entity)
    {
        _applicationDb.Services.Update(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        _applicationDb.Services.Remove(await _applicationDb.Services.FirstOrDefaultAsync(x => x.Id == id));
    }

    public async Task<IEnumerable<Service>> GetServicesByMasterAsync(User user)
    {
        return await _applicationDb.Services.Where(x => x.Master == user).ToListAsync();
    }

    public async Task<IEnumerable<Service>> GetByTypeAsync(ServiceType type)
    {
        return await _applicationDb.Services.Where(x => x.ServiceType == type).ToListAsync();
    }
}