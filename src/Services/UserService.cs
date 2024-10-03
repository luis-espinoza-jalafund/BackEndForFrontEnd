using BackEndForFrontEnd.Domain.Entities;
using BackEndForFrontEnd.Repositories.Interfaces;
using BackEndForFrontEnd.Services.Interfaces;
using Domain.DTOs;

namespace BackEndForFrontEnd.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync(int? limit = null)
    {
        return await _userRepository.GetAllAsync(limit);
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if(user == null)
        {
            throw new ArgumentException("User not found");
        }
        return user;
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if(user == null)
        {
            throw new ArgumentException("User not found");
        }
        return await _userRepository.DeleteAsync(id);
    }

    public async Task<User?> GetUserByNameAsync(string name)
    {
        return await _userRepository.GetByNameAsync(name);
    }

    public async Task<User> UpdateUserAsync(Guid id, CreateUser user)
    {
        var existingUser = await _userRepository.GetByIdAsync(id);
        if(existingUser == null)
        {
            throw new ArgumentException("User not found");
        }

        existingUser.Name = user.Name;
        existingUser.Description = user.Description;
        existingUser.ProfileImage = user.ProfileImage;

        var result = await _userRepository.UpdateAsync(existingUser);
        if(result == null)
        {
            throw new ArgumentException("Failed to update user");
        }
        return existingUser;
    }

    public async Task<User> AddUserAsync(CreateUser user)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            Description = user.Description,
            ProfileImage = user.ProfileImage
        };
        var result = await _userRepository.CreateAsync(newUser);
        if(result == null)
        {
            throw new ArgumentException("Failed to create user");
        }
        return newUser;
    }
}
