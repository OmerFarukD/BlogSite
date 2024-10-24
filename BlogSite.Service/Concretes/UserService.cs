

using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Microsoft.AspNetCore.Identity;

namespace BlogSite.Service.Concretes;

public sealed class UserService(UserManager<User> _userManager) : IUserService
{
    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            Console.WriteLine("Kullanıcı bulunamadı.");
        }

        return user;
    }

    public async Task<User> RegisterAsync(RegisterRequestDto dto)
    {
        User user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            City = dto.City,
            UserName = dto.Username,
           
        };

        var result =await _userManager.CreateAsync(user,dto.Password);

        if (!result.Succeeded)
        {
            Console.WriteLine(result.Errors.ToList().First().Description);
        }

        return user;

    }
}
