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

    public async Task DeleteAsync(Slot entity)
    {
        _applicationDb.Slots.Remove(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task<IEnumerable<Slot>?> GetMasterAvaialableSlotsAsync(int masterId)
    {
        return await _applicationDb.Slots.Where(x => x.MasterId == masterId).ToListAsync();
    }
    
    public Task<List<Slot>> GetUnReservedSlots()
    {
        var unreservedSlots =  _applicationDb.Slots.Where(x => x.Availability == true && x.EndTime < DateTime.UtcNow);
        return unreservedSlots.ToListAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<Slot> slots)
    {
        _applicationDb.Slots.RemoveRange(slots);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task<bool> ExistsSlotsForDateAsync(int masterId, DateOnly date)
    {
        DateTime dateTimeStartUtc = DateTime.SpecifyKind(date.ToDateTime(new TimeOnly(0, 0)), DateTimeKind.Utc);

        return await _applicationDb.Slots
            .AnyAsync(x => x.StartTime.ToUniversalTime().Date == dateTimeStartUtc.Date && x.MasterId == masterId);
    }

    public async Task<DateTime> GetLastSlotGenerationDate()
    {
        var maxDate = await _applicationDb.Slots.MaxAsync(x => (DateTime?)x.EndTime);
        return maxDate ??= DateTime.UtcNow;
    }
}