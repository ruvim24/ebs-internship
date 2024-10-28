using Domain.Entities;

namespace Domain.IRepositories;

public interface ICarRepository
{
    Task AddAsync(Car entity);
    Task<Car?> GetByIdAsync(int id);
    Task<IEnumerable<Car>?> GetAllAsync();
    Task UpdateAsync(Car entity);
    Task DeleteByIdAsync(int id);
    
    //aditional
    Task<Car?> GetCarByCustomerIdAsync(int customerId);
    Task<Car?> GetCarByVINAsync(string vin);
}