using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetByNameAndPasswordAsync(string username, string password);

    Task<User> AddAsync(User user);
}
