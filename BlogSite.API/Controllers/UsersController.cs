using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abstratcts;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService _userService) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterRequestDto dto)
    {
        var result =await _userService.RegisterAsync(dto);

        return Ok(result);
    }

    [HttpGet("email")]
    public async Task<IActionResult> GetByEmail([FromQuery]string email)
    {
        var result = await _userService.GetByEmailAsync(email);
        return Ok(result);
    }
}
