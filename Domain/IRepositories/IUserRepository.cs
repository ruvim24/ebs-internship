using Domain.Entities;
using Domain.Enums;

namespace Domain.IRepositories;

public interface IUserRepository
{
    Task AddAsync(User entity);
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>?> GetAllAsync();
    Task UpdateAsync(User entity);
    Task DeleteAsync(User entity);
    
}