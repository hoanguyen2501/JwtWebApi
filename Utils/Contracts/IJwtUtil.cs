using JwtWebApi.Entities;

namespace JwtWebApi.Utils.Contracts
{
    public interface IJwtUtil
    {
        string GenerateAccessToken(User user);
        int? ValidateAccessToken(string token);
    }
}