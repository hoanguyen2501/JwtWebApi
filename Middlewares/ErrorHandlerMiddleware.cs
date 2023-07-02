using System.Text.Json;
using JwtWebApi.Helpers;

namespace JwtWebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (exception)
                {
                    case AppException e:
                        response.StatusCode = (int)StatusCodes.Status400BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)StatusCodes.Status404NotFound;
                        break;
                    default:
                        response.StatusCode = (int)StatusCodes.Status500InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(
                    new
                    {
                        message = exception?.Message
                    });
                await response.WriteAsync(result);
            }
        }

    }
}