using JwtWebApi.Attributes.Authorization;
using JwtWebApi.DTOs.UserDto;
using JwtWebApi.Entities.Enum;
using JwtWebApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers
{
    [Authorize(roles: Role.Admin)]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            if (users == null)
                return BadRequest();

            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var users = _userService.GetUserById(id);
            if (users == null)
                return BadRequest();

            return Ok(users);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateNewUserDto dto)
        {
            var result = _userService.CreateNewUser(dto);

            if (result <= 0)
                return BadRequest();

            return Ok("Created user successfully");
        }
    }
}