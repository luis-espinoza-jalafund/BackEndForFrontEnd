using BackEndForFrontEnd.Domain.Entities;
using Domain.DTOs;

namespace BackEndForFrontEnd.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User> AddUserAsync(CreateUser user);
    Task<User> UpdateUserAsync(Guid id, CreateUser user);
    Task<bool> DeleteUserAsync(Guid id);
    Task<User?> GetUserByNameAsync(string name);
}
