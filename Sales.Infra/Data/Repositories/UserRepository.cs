using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Repositories;
using Sales.Infra.Data.Contexts;

namespace Sales.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetByNameAndPasswordAsync(string username, string password)
    {
        return await _context.Set<User>().Where(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
    }

}
