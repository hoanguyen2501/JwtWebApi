using JwtWebApi.Attributes.Authorization;
using JwtWebApi.DTOs.UserDto;
using JwtWebApi.Entities.Enum;
using JwtWebApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(roles: Role.Admin)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            if (users == null)
                return BadRequest();

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var currentUser = (UserDto)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != Role.Admin.ToString())
                return Unauthorized(new { message = "Unauthorized" });

            var user = _userService.GetUserById(id);
            if (user == null)
                return BadRequest();

            return Ok(user);
        }

        [HttpGet("profile")]
        public IActionResult GetUserProfile()
        {

            return Ok();
        }

        [Authorize(roles: Role.Admin)]
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