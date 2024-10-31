using Domain.Entities;
using Domain.Enums;
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

    public async Task<Service?> GetByIdAsync(int id)
    {
        return await _applicationDb.Services.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Service>?> GetAllAsync()
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

    public async Task<Service?> GetServicesByMasterAsync(int masterId)
    {
        return await _applicationDb.Services.FirstOrDefaultAsync(x => x.MasterId == masterId);
    }

    public async Task<IEnumerable<Service>?> GetByTypeAsync(ServiceType type)
    {
        return await _applicationDb.Services.Where(x => x.ServiceType == type).ToListAsync();
    }
}