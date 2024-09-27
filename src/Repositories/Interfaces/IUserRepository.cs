using BackEndForFrontEnd.Domain.Entities;

namespace BackEndForFrontEnd.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByNameAsync(string name);
}
