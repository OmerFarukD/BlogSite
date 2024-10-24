using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Users.Requests;

public sealed record RegisterRequestDto
    (
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Username,
    string City    
    );
