using System.Text;
using System.Security.Cryptography;
using JwtWebApi.Data;
using JwtWebApi.DTOs.UserDto;
using JwtWebApi.Entities;
using JwtWebApi.Services.Contracts;

namespace JwtWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly JwtWebApiDbContext _context;
        // private readonly HttpContext _httpContext;

        public UserService(JwtWebApiDbContext context)
        {
            _context = context;
        }

        public IList<UserDto> GetAllUsers()
        {
            IList<User> users = _context.Users.ToList();
            IList<UserDto> userDtos = users.Select(x => new UserDto(x)).ToList();
            return userDtos;
        }

        public UserDto GetUserById(int id)
        {
            User user = _context.Users.Find(id);
            return new UserDto(user);
        }

        public UserDto GetUserByUsername(string username)
        {
            return _context.Users.Where(x => x.Username == username)
                                .Select(x => new UserDto(x))
                                .FirstOrDefault();
        }

        public int CreateNewUser(CreateNewUserDto model)
        {
            if (IsUserExisted(model.Username))
                return 0;

            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            return _context.SaveChanges();
        }

        private bool IsUserExisted(string username)
        {
            return _context.Users.Any(x => x.Username == username);
        }
    }
}