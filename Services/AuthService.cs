using System.Text;
using System.Security.Cryptography;
using JwtWebApi.Data;
using JwtWebApi.DTOs.Auth;
using JwtWebApi.Services.Contracts;
using JwtWebApi.Entities;
using JwtWebApi.Utils.Contracts;

namespace JwtWebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtWebApiDbContext _context;
        private readonly IJwtUtil _jwtUtil;

        public AuthService(JwtWebApiDbContext context, IJwtUtil jwtUtil)
        {
            _context = context;
            _jwtUtil = jwtUtil;
        }

        public LoginResponseDto Login(LoginRequestDto model)
        {
            var user = _context.Users.Where(x => x.Username == model.Username)
                                    .FirstOrDefault();

            if (!(user != null && IsValidatedPassword(model.Password, user)))
                return null;

            LoginResponseDto response = new()
            {
                Username = model.Username,
                Token = _jwtUtil.GenerateAccessToken(user)
            };

            return response;
        }

        private bool IsValidatedPassword(string password, User user)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            int computedHashLength = Buffer.ByteLength(computedHash);
            for (int i = 0; i < computedHashLength; ++i)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return false;
            }

            return true;
        }
    }
}