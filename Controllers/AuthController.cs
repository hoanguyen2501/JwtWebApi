using JwtWebApi.Attributes.Authorization;
using JwtWebApi.DTOs.Auth;
using JwtWebApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers
{

    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto request)
        {
            var response = _authService.Login(request);
            if (response == null)
                return BadRequest("Username or password is incorrect");

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }
    }
}