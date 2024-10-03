using Domain.DTOs;
using BackEndForFrontEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BackEndForFrontEnd.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    private bool IsMobileRequest(HttpRequest request)
    {
        var userAgent = request.Headers["User-Agent"].ToString();
        return Regex.IsMatch(userAgent, 
            "(android|bb\\d+|meego).+mobile|" +
            "avantgo|bada\\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|" +
            "ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|" +
            "opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\\/|plucker|pocket|psp|" +
            "series(4|6)0|symbian|treo|up\\.(browser|link)|vodafone|wap|windows ce|" +
            "xda|xiino", 
            RegexOptions.IgnoreCase);
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
        var isMobile = IsMobileRequest(Request);
        int? limit = isMobile ? 20 : null;
        var users = await _userService.GetAllUsersAsync(limit);
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
