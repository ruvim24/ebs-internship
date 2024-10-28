using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContext;

namespace Persistence.Repositories;

public class SlotRepository : ISlotRepository
{
    private readonly ApplicationDbContext _applicationDb;

    public SlotRepository(ApplicationDbContext applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task AddAsync(Slot entity)
    {
         _applicationDb.Slots.Add(entity);
         await _applicationDb.SaveChangesAsync();
    }

    public async Task<Slot?> GetByIdAsync(int id)
    {
        return await _applicationDb.Slots.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Slot>> GetAllAsync()
    {
        return await _applicationDb.Slots.ToListAsync();
    }

    public async Task UpdateAsync(Slot entity)
    {
        _applicationDb.Update(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        _applicationDb.Slots.Remove(await _applicationDb.Slots.FirstOrDefaultAsync(x => x.Id == id));
        await _applicationDb.SaveChangesAsync();
    }

    public async Task<IEnumerable<Slot>?> GetMasterAvaialableSlotsAsync(int masterId)
    {
        return await _applicationDb.Slots.Where(x => x.MasterId == masterId).ToListAsync();
    }

    public async Task<IEnumerable<Slot>> GetAvailableSlotsAsync()
    {
        return await _applicationDb.Slots.Where(x => x.Availability == true).ToListAsync();
    }
}