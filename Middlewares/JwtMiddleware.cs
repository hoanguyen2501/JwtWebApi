using JwtWebApi.Services.Contracts;
using JwtWebApi.Utils.Contracts;

namespace JwtWebApi.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtUtil jwtUtil, IUserService userService)
        {
            string token = context.Request.Headers["Authorization"]
                                        .FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtil.ValidateAccessToken(token);

            if (userId != null)
            {
                context.Items["User"] = userService.GetUserById(userId.Value);
            }

            await _next(context);
        }
    }
}