using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContext;

namespace Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _applicationDb;

    public CarRepository(ApplicationDbContext applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task AddAsync(Car entity)
    {
        await _applicationDb.Cars.AddAsync(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task<Car?> GetByIdAsync(int id)
    {
        return await _applicationDb.Cars.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Car>?> GetAllAsync()
    {
        return await _applicationDb.Cars.ToListAsync();
    }

    public async Task UpdateAsync(Car entity)
    {
        _applicationDb.Cars.Update(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task DeleteAsync(Car entity)
    {
        _applicationDb.Cars.Remove(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task<Car?> GetCarByCustomerIdAsync(int customerId)
    {
        return await _applicationDb.Cars.FirstOrDefaultAsync(x => x.CustomerId == customerId);
    }
}