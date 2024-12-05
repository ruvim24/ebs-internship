using Domain.Entities;

namespace Domain.IRepositories;

public interface ISlotRepository
{
    Task AddAsync(Slot entity);
    Task<Slot?> GetByIdAsync(int id);
    Task<IEnumerable<Slot>> GetAllAsync();
    Task UpdateAsync(Slot entity);
    Task DeleteAsync(Slot entity);

    //aditional
    Task<IEnumerable<Slot>?> GetMasterAvaialableSlotsAsync(int masterId);
    Task<List<Slot>> GetUnReservedSlots();

    Task DeleteRangeAsync(IEnumerable<Slot> slots);

    public Task<bool> ExistsSlotsForDateAsync(int masterId, DateOnly date);

    Task<DateTime> GetLastSlotGenerationDate();
    Task<DateTime> GetLastSlotGenerationDateForService(int masterId);

    public Task<IEnumerable<Slot>> GetMastersAvailableSlotsForDate(DateTime date, int masterId);

}