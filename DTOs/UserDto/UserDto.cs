using JwtWebApi.Entities;

namespace JwtWebApi.DTOs.UserDto
{
    public record UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public UserDto(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Role = user.Role.ToString();
        }
    }
}