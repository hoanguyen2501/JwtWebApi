using JwtWebApi.DTOs.UserDto;

namespace JwtWebApi.Services.Contracts
{
    public interface IUserService
    {
        IList<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        UserDto GetUserByUsername(string username);
        int CreateNewUser(CreateNewUserDto model);
    }
}