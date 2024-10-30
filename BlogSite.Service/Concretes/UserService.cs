

using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace BlogSite.Service.Concretes;

public sealed class UserService(UserManager<User> _userManager) : IUserService
{
    public async Task<User> ChangePasswordAsync(string id, ChangePasswordRequestDto requestDto)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }
        if (requestDto.NewPassword.Equals(requestDto.NewPasswordAgain) is false)
        {
            throw new BusinessException("Parola Uyuşmuyor.");
        }

        var result = await _userManager.ChangePasswordAsync(user,requestDto.CurrentPassword,requestDto.NewPassword);
        CheckForIdentityResult(result);

        return user;
    }
    

    public async Task<string> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if(user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        var result = await _userManager.DeleteAsync(user);
        CheckForIdentityResult(result);

        return "Kullanıcı Silindi.";

    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        return user;
    }

    public async Task<User> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);

        if(user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        bool checkPassword = await _userManager.CheckPasswordAsync(user,dto.Password);

        if (checkPassword is false)
        {
            throw new BusinessException("Parolanız yanlış.");
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
        CheckForIdentityResult(result);

        var addRole = await _userManager.AddToRoleAsync(user,"User");
        CheckForIdentityResult(addRole);

        return user;
    }

    public async Task<User> UpdateAsync(string id, UserUpdateRequestDto dto)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        user.UserName = dto.Username;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.City = dto.City;


        var result = await _userManager.UpdateAsync(user);
        CheckForIdentityResult(result);

        return user;
    }


    private void CheckForIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }
    }
}
