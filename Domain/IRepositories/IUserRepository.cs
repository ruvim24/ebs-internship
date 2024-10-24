using Domain.Domain.Entitites;
using Domain.Entities.Enums;

namespace Domain.IRepositories;

public interface IUserRepository
{
    Task AddAsync(User entity);
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task UpdateAsync(User entity);
    Task DeleteByIdAsync(int id);
    
    //aditional
    Task<IEnumerable<User>> GetByRoleAsync(Role role);
    
}