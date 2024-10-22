

using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Microsoft.AspNetCore.Identity;

namespace BlogSite.Service.Concretes;

public sealed class UserService(UserManager<User> _userManager) : IUserService
{
    public Task<User> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> Register(RegisterRequestDto dto)
    {
        throw new NotImplementedException();
    }
}
