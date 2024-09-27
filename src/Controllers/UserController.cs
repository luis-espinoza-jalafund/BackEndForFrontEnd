using Domain.DTOs;
using BackEndForFrontEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndForFrontEnd.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseUser), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUser([FromBody] CreateUser user)
    {
        var newUser = await _userService.AddUserAsync(user);
        var response = ResponseUser.FromDomain(newUser);
        return CreatedAtAction(nameof(GetUserById), new { Id = newUser.Id }, response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseUser), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound("User not found.");
        }
        var response = ResponseUser.FromDomain(user);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ResponseUser>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        var response = users.Select(u => ResponseUser.FromDomain(u));
        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseUser), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] CreateUser user)
    {
        var updatedUser = await _userService.UpdateUserAsync(id, user);
        var response = ResponseUser.FromDomain(updatedUser);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        if (!deleted)
        {
            return NotFound("User not found.");
        }
        return NoContent();
    }

    [HttpGet("name/{name}")]
    [ProducesResponseType(typeof(ResponseUser), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserByName(string name)
    {
        var user = await _userService.GetUserByNameAsync(name);
        if (user == null)
        {
            return NotFound("User not found.");
        }
        var response = ResponseUser.FromDomain(user);
        return Ok(response);
    }
}
