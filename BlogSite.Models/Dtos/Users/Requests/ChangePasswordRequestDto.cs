using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Users.Requests
{
    public sealed record ChangePasswordRequestDto(string CurrentPassword, string NewPassword, string NewPasswordAgain);
}
