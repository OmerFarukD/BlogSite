using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Dtos.Users.Requests;
using Core.Responses;

namespace BlogSite.Service.Abstratcts;

public interface IAuthenticationService
{
    Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto);
    Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto);
}
