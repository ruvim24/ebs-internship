using Domain.Entities;
using Domain.Enums;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContext;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _applicationDb;

    public UserRepository(ApplicationDbContext applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task AddAsync(User entity)
    {
        _applicationDb.Users.Add(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _applicationDb.Users.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<User>?> GetAllAsync()
    {
        return await _applicationDb.Users.ToListAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        _applicationDb.Users.Update(entity);
        await _applicationDb.SaveChangesAsync();
    }

    public async Task DeleteAsync(User entity)
    {
        _applicationDb.Users.Remove(entity);
        await _applicationDb.SaveChangesAsync();
    }
}