using JwtWebApi.DTOs.UserDto;
using JwtWebApi.Entities.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JwtWebApi.Attributes.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public AuthorizeAttribute()
        {
            _roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
        }

        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata
                                        .OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var user = (UserDto)context.HttpContext.Items["User"];
            if (user == null ||
                (_roles.Any() && !_roles.Contains((Role)Enum.Parse(typeof(Role), user.Role))))
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" })
                { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}