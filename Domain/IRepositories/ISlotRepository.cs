using Domain.Domain.Entitites;

namespace Domain.IRepositories;

public interface ISlotRepository
{
    Task AddAsync(Slot entity);
    Task<Slot?> GetByIdAsync(int id);
    Task<IEnumerable<Slot>> GetAllAsync();
    Task UpdateAsync(Slot entity);
    Task DeleteByIdAsync(int id);

    //aditional
    Task<IEnumerable<Slot>> GetMasterAvaialableSlotsAsync(User master /*int MasterId??*/);
    Task<IEnumerable<Slot>> GetAvailableSlotsAsync();
}