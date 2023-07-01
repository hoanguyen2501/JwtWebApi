using JwtWebApi.DTOs.Auth;

namespace JwtWebApi.Services.Contracts
{
    public interface IAuthService
    {
        LoginResponseDto Login(LoginRequestDto model);
    }
}