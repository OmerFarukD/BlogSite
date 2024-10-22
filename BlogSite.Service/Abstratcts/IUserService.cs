using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstratcts;

public interface IUserService
{

    Task<User> Register(RegisterRequestDto dto);
    Task<User> GetByEmail(string email);

}
